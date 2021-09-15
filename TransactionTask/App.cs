namespace TransactionTask
{
    internal class App
    {
        private static void Main(string[] args)
        {
            Utils.InsertWithTransaction("newCategory1");
            Utils.InsertWithoutTransaction("newCategory2");
        }
    }
}
