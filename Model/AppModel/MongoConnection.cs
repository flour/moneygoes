namespace moneygoes.Models.AppModel
{
    public class MongoConnection
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

        public override string ToString()
        {
            return $"{ConnectionString.Trim('/')}/{DatabaseName.Trim('/')}";
        }
    }
}