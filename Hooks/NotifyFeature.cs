namespace Notify;

/// <summary>
/// These are the different features available for notification in this mod.
/// </summary>
/// <remarks>
/// These are used for command parsing and internally, if you change them you're changing
/// the command that gets parsed as well.
/// </remarks>
public enum NotifyFeature
{
    motd,
    newuser,
    offline,
    online,
    auto,
    vblood
}