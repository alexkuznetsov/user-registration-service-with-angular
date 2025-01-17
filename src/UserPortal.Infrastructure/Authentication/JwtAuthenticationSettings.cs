﻿namespace UserPortal.Infrastructure.Authentication;

/// <summary>
/// JWT settings from configuration
/// </summary>
public class JwtAuthenticationSettings
{
    public bool ValidateIssuer { get; set; } = true;
    public bool ValidateAudience { get; set; } = false;
    public bool ValidateIssuerSigningKey { get; set; } = true;
    public string ValidIssuer { get; set; } = "UserPortalApi";
    public string ValidAudience { get; set; } = "UserPortalApi";

    public string IssuerSigningKey { get; set; } = "su@EKey@2@*as#Q%Q(#(@#2$@";
    public int TimeToLive { get; set; } = 30;
}