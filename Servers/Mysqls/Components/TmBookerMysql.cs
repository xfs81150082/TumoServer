namespace Servers 
{
    class BookerMysqlTabler : TmSoulerdbMysql
    {
        public override void TmAwake()
        {
            base.TmAwake();
            TmSoulerdbName = "bookeritem";
        }
    }
}