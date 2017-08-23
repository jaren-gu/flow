using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
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
        /// 向数据库中插入单条数据
        /// </summary>
        /// <param name="bson"></param>
        public async Task InsertOne(BsonDocument bson)
        {
            //await MongoDBHelper.GetInstance().InsertOne(bson);
            await collection.InsertOneAsync(bson);
        }

        /// <summary>
        /// 向数据库中插入多条数据
        /// </summary>
        /// <param name="documents"></param>
        /// <returns></returns>
        public async Task InsertMany(List<BsonDocument> documents)
        {
            //await MongoDBHelper.GetInstance().InsertMany(documents);
            await collection.InsertManyAsync(documents);
        }

        /// <summary>
        /// 获取数据表中的条目数
        /// </summary>
        /// <returns></returns>
        public async Task<long> GetCollectionCount()
        {
            //long count = await MongoDBHelper.GetInstance().GetCollectionCount();
            //JObject j = new JObject();
            //j["count"] = count;
            //return j;
            return await collection.CountAsync(new BsonDocument());
        }

        /// <summary>
        /// 找出数据表中第一条记录
        /// </summary>
        /// <returns></returns>
        public async Task<BsonDocument> GetFirstDocument()
        {
            //var document = await MongoDBHelper.GetInstance().GetFirstDocument();
            //var jsonWriterSettings = new JsonWriterSettings { OutputMode = JsonOutputMode.Strict };
            //return JObject.Parse(document.ToJson<MongoDB.Bson.BsonDocument>(jsonWriterSettings));
            return await collection.Find(new BsonDocument()).FirstOrDefaultAsync();
        }

        /// <summary>
        /// 获取全部数据
        /// </summary>
        /// <returns></returns>
        public async Task<List<BsonDocument>> GetAllDocuments()
        {
            //var docs = await MongoDBHelper.GetInstance().GetAllDocuments();
            //List<JObject> js = new List<JObject>();
            //var jsonWriterSettings = new JsonWriterSettings { OutputMode = JsonOutputMode.Strict };
            //docs.ForEach(d => js.Add(JObject.Parse(d.ToJson<MongoDB.Bson.BsonDocument>(jsonWriterSettings))));
            //string s = Newtonsoft.Json.JsonConvert.SerializeObject(js);
            //return JArray.Parse(s);
            return await collection.Find(new BsonDocument()).ToListAsync();
        }

        /// <summary>
        /// 根据条件获取单条数据
        /// </summary>
        /// <returns></returns>
        public async Task<BsonDocument> GetDocumentWithFilter(string key, object value)
        {
            //var doc = await MongoDBHelper.GetInstance().GetDocumentWithFilter("Id", 2.0);
            //var jsonWriterSettings = new JsonWriterSettings { OutputMode = JsonOutputMode.Strict };
            //return JObject.Parse(doc.ToJson<MongoDB.Bson.BsonDocument>(jsonWriterSettings));
            var filter = Builders<BsonDocument>.Filter.Eq(key, value);
            return await collection.Find(filter).FirstAsync();
        }

        /// <summary>
        /// 根据条件获取数据集
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public async Task<List<BsonDocument>> GetDocumentsWithFilter(string key, object value)
        {
            //var docs = await MongoDBHelper.GetInstance().GetDocumentsWithFilter("Id", 2.0);
            //List<JObject> js = new List<JObject>();
            //var jsonWriterSettings = new JsonWriterSettings { OutputMode = JsonOutputMode.Strict };
            //docs.ForEach(d => js.Add(JObject.Parse(d.ToJson<MongoDB.Bson.BsonDocument>(jsonWriterSettings))));
            //string s = Newtonsoft.Json.JsonConvert.SerializeObject(js);
            //return JArray.Parse(s);
            var filter = Builders<BsonDocument>.Filter.Eq(key, value);
            return await collection.Find(filter).ToListAsync();
        }
    }
}