using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XcaInteropService.Commons.Models.Custom.AccessToken;

public class AccessToken
{
    public DateTime IssuedAt { get; set; }
    public string Value { get; set; }
    public int Duration { get; set; }

    public bool IsValid()
    {
        return DateTime.UtcNow.AddSeconds(-Duration) <= IssuedAt;
    }
}
