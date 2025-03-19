using System.Text;
using LevelDB;

var dir = "C:\\Users\\alex\\ddg\\shared_proto_db";
// foreach (var file in Directory.GetFiles(dir))
// {
//     var bytes = File.ReadAllBytes(file);
//     var str = Encoding.ASCII.GetString(bytes);
//     Console.Write(Path.GetRelativePath(dir, file)+"|");
//     Console.WriteLine(str.Contains("foobar") ? "Contains foobar" : "Does not contain foobar");
// }

Console.WriteLine("---------------");
var options = new Options { CreateIfMissing = false };
var db = new DB(options, dir);
foreach (var (key, value) in db)
{
    var keyStr = Encoding.ASCII.GetString(key);
    var valueStr = Encoding.ASCII.GetString(value);
    Console.WriteLine($"{keyStr} => {valueStr}");
}
Console.WriteLine("---------------");
db.Compact();
db.Close();
db.Dispose();

// foreach (var file in Directory.GetFiles(dir))
// {
//     var bytes = File.ReadAllBytes(file);
//     var str = Encoding.ASCII.GetString(bytes);
//     Console.Write(Path.GetRelativePath(dir, file)+"|");
//     Console.WriteLine(str.Contains("foobar") ? "Contains foobar" : "Does not contain foobar");
// }
