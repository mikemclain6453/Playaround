using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class CompiledRepositories
{
    private PrimaryAccountRepository PAR = new PrimaryAccountRepository();
    private PrimaryAccountMap PAM = new PrimaryAccountMap();
    private SessionsRepository SR = new SessionsRepository();
    private SessionsMap SM = new SessionsMap();
    private CoinBankRepository CBR = new CoinBankRepository();
    private CoinBankMap CBM = new CoinBankMap();
    private TotalCoinsRepository TCR = new TotalCoinsRepository();
    private TotalCoinsMap TCM = new TotalCoinsMap();
    private CoinOrderRepository COR = new CoinOrderRepository();
    private CoinOrderMap COM = new CoinOrderMap();
    private LogsRepository LR = new LogsRepository();
    private LogsMap LM = new LogsMap();

    public dynamic repositoryGrab(databaseTable DBT)
    {
        switch (DBT)
        {
            case databaseTable.PrimaryAccount:
                return PAR;
            case databaseTable.Sessions:
                return SR;
            case databaseTable.CoinBank:
                return CBR;
            case databaseTable.TotalCoins:
                return TCR;
            case databaseTable.CoinOrder:
                return COR;
            case databaseTable.Logs:
                return LR;
            default:
                return null;
        }
    }

    public dynamic mapGrab(databaseTable DBT)
    {
        switch (DBT)
        {
            case databaseTable.PrimaryAccount:
                return PAM;
            case databaseTable.Sessions:
                return SM;
            case databaseTable.CoinBank:
                return CBM;
            case databaseTable.TotalCoins:
                return TCM;
            case databaseTable.CoinOrder:
                return COM;
            case databaseTable.Logs:
                return LM;
            default:
                return null;
        }
    }
}
public class RepoMapConnect
{
    public dynamic map;
    public dynamic repo;
    public functionality func = new functionality();

    public RepoMapConnect(databaseTable DBT)
    {
        CompiledRepositories CR = new CompiledRepositories();
        this.map = CR.mapGrab(DBT);
        this.repo = CR.repositoryGrab(DBT);
    }
}