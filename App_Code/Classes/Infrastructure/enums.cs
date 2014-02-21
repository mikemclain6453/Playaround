using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public enum databaseAction
{
    Execute,
    Read
}

public enum sqlStatementType
{
    Insert,
    Update,
    Delete
}

public enum tableFunction
{
    tableFormatChoose,
    processRow,
    sqlParamPopulate,
    paramArray,
}

public enum imageTypes
{
    PNG,
    JPG,
    JPEG,
    NONE
}

public enum coinType
{
    NULL,
    Bitcoin,
    Litecoin
}
public enum orderType
{
    NULL,
    Buy,
    Sell
}
public enum logType
{
    Register,
    Verify,
    Login,
    TradePost,
    TradeConfirmation
}
public enum membership
{
    NULL,
    Unverified, // No Deposits
    Verified,   // Deposit Made - Lowest Priorities Tier 3, Default Cashout, Standard Mail
    Bronze,     // $5.00 Monthly - Priority in orders Tier 2, 25% Cheaper Cashout, Certified Mail
    Silver,     // $10.00 Monthly - Priority in orders Tier 2, 50% Cheaper Cashout, Certified Mail
    Gold,       // $15.00 Monthly - Priority in orders Tier 1, 75% Cheaper Cashout, Certified Mail
    Platinum    // $20.00 Monthly - Priority in orders Tier 1, Free Cashout, Certified Mail
}
public enum administrativeTrust
{
    NULL,
    Banned,
    Unknown,
    Low,
    Medium,
    High
}