using System.Runtime.InteropServices;

namespace Controls.TitleBar.Services;

public static class PlatformInfoService
{
    public static bool IsMac { get; } = RuntimeInformation.IsOSPlatform(OSPlatform.OSX);
}
