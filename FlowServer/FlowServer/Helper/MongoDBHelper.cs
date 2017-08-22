using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace FlowServer.Helper
{
    public class MongoDBHelper
    {
        private static MongoDBHelper helper;
        private static object locker = new object();
        MongoClient client;
        IMongoDatabase database;
        IMongoCollection<BsonDocument> collection;

        private MongoDBHelper()
        {
            string mongoDB = ConfigHelper.GetInstance().GetValue("MongoDB");
            client = new MongoClient(mongoDB);
        }

        /// <summary>
        /// 获取实例
        /// </summary>
        /// <returns></returns>
        public static MongoDBHelper GetInstance()
        {
            if (helper == null)
            {
                lock (locker)
                {
                    if (helper == null)
                    {
                        helper = new MongoDBHelper();
                    }
                }
            }
            return helper;
        }

        /// <summary>
        /// 连接数据库
        /// </summary>
        /// <param name="dataBase"></param>
        public void Connect(string dataBase, string collectionName)
        {
            database = client.GetDatabase(dataBase);
            collection = database.GetCollection<BsonDocument>(collectionName);
        }

        /// <summary>
        /// 向数据库中插入数据
        /// </summary>
        /// <param name="bson"></param>
        public async Task InsertOne(BsonDocument bson)
        {
            await collection.InsertOneAsync(bson);
        }
    }
}