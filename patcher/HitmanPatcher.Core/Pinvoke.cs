using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace HitmanPatcher
{
    [Flags]
    public enum MemProtection : uint
    {
        PAGE_EXECUTE = 0x00000010,
        PAGE_EXECUTE_READ = 0x00000020,
        PAGE_EXECUTE_READWRITE = 0x00000040,
        PAGE_EXECUTE_WRITECOPY = 0x00000080,
        PAGE_NOACCESS = 0x00000001,
        PAGE_READONLY = 0x00000002,
        PAGE_READWRITE = 0x00000004,
        PAGE_WRITECOPY = 0x00000008,
        PAGE_GUARD = 0x00000100,
        PAGE_NOCACHE = 0x00000200,
        PAGE_WRITECOMBINE = 0x00000400
    }

    [Flags]
    public enum ProcessAccess : uint
    {
        PROCESS_QUERY_INFORMATION = 0x0400,
        PROCESS_VM_READ = 0x0010,
        PROCESS_VM_WRITE = 0x0020,
        PROCESS_VM_OPERATION = 0x0008,
        PROCESS_SET_QUOTA = 0x0100,
        PROCESS_TERMINATE = 0x0001
    }

    public enum PROCESSINFOCLASS
    {
        ProcessBasicInformation = 0,
        ProcessDebugPort = 7,
        ProcessWow64Information = 26,
        ProcessImageFileName = 27,
        ProcessBreakOnTermination = 29,
        ProcessSubsystemInformation = 75
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct PROCESS_BASIC_INFORMATION
    {
        public IntPtr Reserved1;
        public IntPtr PebBaseAddress;
        public IntPtr Reserved2_0;
        public IntPtr Reserved2_1;
        public IntPtr UniqueProcessId;
        public IntPtr Reserved3;
    }

    public enum JOBOBJECTINFOCLASS
    {
        JobObjectExtendedLimitInformation = 9,
        JobObjectBasicLimitInformation = 2
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct JOBOBJECT_BASIC_LIMIT_INFORMATION
    {
        public long PerProcessUserTimeLimit;
        public long PerJobUserTimeLimit;
        public uint LimitFlags;
        public UIntPtr MinimumWorkingSetSize;
        public UIntPtr MaximumWorkingSetSize;
        public uint ActiveProcessLimit;
        public UIntPtr Affinity;
        public uint PriorityClass;
        public uint SchedulingClass;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct JOBOBJECT_EXTENDED_LIMIT_INFORMATION
    {
        public JOBOBJECT_BASIC_LIMIT_INFORMATION BasicLimitInformation;
        public IO_COUNTERS IoInfo;
        public UIntPtr ProcessMemoryLimit;
        public UIntPtr JobMemoryLimit;
        public UIntPtr PeakProcessMemoryUsed;
        public UIntPtr PeakJobMemoryUsed;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct IO_COUNTERS
    {
        public ulong ReadOperationCount;
        public ulong WriteOperationCount;
        public ulong OtherOperationCount;
        public ulong ReadTransferCount;
        public ulong WriteTransferCount;
        public ulong OtherTransferCount;
    }

    public static class Pinvoke
    {
        public const uint JOB_OBJECT_LIMIT_KILL_ON_JOB_CLOSE = 0x2000;

        [DllImport("kernel32", SetLastError = true)]
        public static extern IntPtr OpenProcess(ProcessAccess dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32", SetLastError = true)]
        public static extern bool CloseHandle(IntPtr hObject);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool WriteProcessMemory([In] IntPtr hProcess, [In] IntPtr address, [In, MarshalAs(UnmanagedType.LPArray)] byte[] buffer, [In] UIntPtr size, [Out] out UIntPtr byteswritten);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool ReadProcessMemory([In] IntPtr hProcess, [In] IntPtr address, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] byte[] buffer, [In] UIntPtr size, [Out] out UIntPtr numberOfBytesRead);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool VirtualProtectEx([In] IntPtr hProcess, [In] IntPtr lpAddress, [In] UIntPtr dwSize, [In] MemProtection flNewProtect, [Out] out MemProtection lpflOldProtect);

        [DllImport("ntdll.dll")]
        public static extern int NtQueryInformationProcess(IntPtr hProcess, PROCESSINFOCLASS processInformationClass, out PROCESS_BASIC_INFORMATION processInformation, uint processInformationLength, out uint returnLength);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr CreateJobObject(IntPtr lpJobAttributes, string lpName);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool SetInformationJobObject(IntPtr hJob, JOBOBJECTINFOCLASS JobObjectInformationClass, ref JOBOBJECT_EXTENDED_LIMIT_INFORMATION lpJobObjectInformation, uint cbJobObjectInformationLength);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool AssignProcessToJobObject(IntPtr hJob, IntPtr hProcess);

        public static int GetProcessParentPid(Process process)
        {
            IntPtr hProcess = OpenProcess(
                ProcessAccess.PROCESS_VM_READ
                | ProcessAccess.PROCESS_QUERY_INFORMATION,
                false, process.Id);

            if (hProcess == IntPtr.Zero)
            {
                throw new Win32Exception(Marshal.GetLastWin32Error(), "Failed to get a process handle.");
            }

            PROCESS_BASIC_INFORMATION PEB = new PROCESS_BASIC_INFORMATION();

            int result = NtQueryInformationProcess(hProcess,
                PROCESSINFOCLASS.ProcessBasicInformation, out PEB,
                (uint) Marshal.SizeOf(PEB), out _);

            CloseHandle(hProcess);
            if (result != 0)
            {
                throw new Win32Exception(result, "(NTSTATUS)");
            }

            return PEB.Reserved3.ToInt32();
        }
    }
}
