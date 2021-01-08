using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHAT_WPF.Models
{
    public class ContactTabModel
    {
        public List<string> FriendIDs { get; set; }
        public List<string> SuggestedUserIDs { get; set; } 
        public KeyValuePair<string, UserModel> ShowedUser { get; set; }
    }
}
