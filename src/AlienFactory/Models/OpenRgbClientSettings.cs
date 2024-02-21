namespace AlienFactory.Models;

using System.ComponentModel.DataAnnotations;

public record OpenRgbClientSettings(
    string IpAddress = "127.0.0.1",
    int Port = 6742,
    string Name = "Alien Factory",
    bool AutoConnect = true,
    int TimeoutMs = 1_000,
    uint ProtocolVersionNumber = OpenRgbClientSettings.DefaultProtocolVersion)
{
    private const int DefaultProtocolVersion = 4;

    // TODO IpAddress v4 or v6 validation
    public string IpAddress { get; init; } = IpAddress;

    // TODO Port validation
    public int Port { get; init; } = Port;

    [MinLength(1)]
    public string Name { get; init; } = Name;

    public bool AutoConnect { get; init; } = AutoConnect;

    [Range(minimum: 10, 10_000)]
    public int TimeoutMs { get; init; } = TimeoutMs;

    [Range(0, 4)]
    public uint ProtocolVersionNumber { get; init; } = ProtocolVersionNumber;
}

