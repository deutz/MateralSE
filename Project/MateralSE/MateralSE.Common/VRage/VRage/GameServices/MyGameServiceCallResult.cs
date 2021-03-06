﻿namespace VRage.GameServices
{
    using System;

    public enum MyGameServiceCallResult
    {
        OK = 1,
        Fail = 2,
        NoConnection = 3,
        InvalidPassword = 5,
        LoggedInElsewhere = 6,
        InvalidProtocolVer = 7,
        InvalidParam = 8,
        FileNotFound = 9,
        Busy = 10,
        InvalidState = 11,
        InvalidName = 12,
        InvalidEmail = 13,
        DuplicateName = 14,
        AccessDenied = 15,
        Timeout = 0x10,
        Banned = 0x11,
        AccountNotFound = 0x12,
        InvalidSteamID = 0x13,
        ServiceUnavailable = 20,
        NotLoggedOn = 0x15,
        Pending = 0x16,
        EncryptionFailure = 0x17,
        InsufficientPrivilege = 0x18,
        LimitExceeded = 0x19,
        Revoked = 0x1a,
        Expired = 0x1b,
        AlreadyRedeemed = 0x1c,
        DuplicateRequest = 0x1d,
        AlreadyOwned = 30,
        IPNotFound = 0x1f,
        PersistFailed = 0x20,
        LockingFailed = 0x21,
        LogonSessionReplaced = 0x22,
        ConnectFailed = 0x23,
        HandshakeFailed = 0x24,
        IOFailure = 0x25,
        RemoteDisconnect = 0x26,
        ShoppingCartNotFound = 0x27,
        Blocked = 40,
        Ignored = 0x29,
        NoMatch = 0x2a,
        AccountDisabled = 0x2b,
        ServiceReadOnly = 0x2c,
        AccountNotFeatured = 0x2d,
        AdministratorOK = 0x2e,
        ContentVersion = 0x2f,
        TryAnotherCM = 0x30,
        PasswordRequiredToKickSession = 0x31,
        AlreadyLoggedInElsewhere = 50,
        Suspended = 0x33,
        Cancelled = 0x34,
        DataCorruption = 0x35,
        DiskFull = 0x36,
        RemoteCallFailed = 0x37,
        PasswordUnset = 0x38,
        ExternalAccountUnlinked = 0x39,
        PSNTicketInvalid = 0x3a,
        ExternalAccountAlreadyLinked = 0x3b,
        RemoteFileConflict = 60,
        IllegalPassword = 0x3d,
        SameAsPreviousValue = 0x3e,
        AccountLogonDenied = 0x3f,
        CannotUseOldPassword = 0x40,
        InvalidLoginAuthCode = 0x41,
        AccountLogonDeniedNoMail = 0x42,
        HardwareNotCapableOfIPT = 0x43,
        IPTInitError = 0x44,
        ParentalControlRestricted = 0x45,
        FacebookQueryError = 70,
        ExpiredLoginAuthCode = 0x47,
        IPLoginRestrictionFailed = 0x48,
        AccountLockedDown = 0x49,
        AccountLogonDeniedVerifiedEmailRequired = 0x4a,
        NoMatchingURL = 0x4b,
        BadResponse = 0x4c,
        RequirePasswordReEntry = 0x4d,
        ValueOutOfRange = 0x4e
    }
}

