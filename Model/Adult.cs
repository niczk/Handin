using System.Text.Json;
using System.Text.Json.Serialization;

namespace Handin1.Model {
public class Adult : Person {
    [JsonPropertyName("jobTitle")]
    public string JobTitle { get; set; }

    public override string ToString() {
        return JsonSerializer.Serialize(this);
    }

    public void Update(Adult toUpdate) {
        JobTitle = toUpdate.JobTitle;
        base.Update(toUpdate);
    }

}
}