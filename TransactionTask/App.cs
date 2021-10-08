namespace TransactionTask
{
    internal class App
    {
        private static void Main(string[] args)
        {
            Utils.InsertWithTransaction("newCategory");

            Utils.InsertWithoutTransaction("newCategory");
        }
    }
}
