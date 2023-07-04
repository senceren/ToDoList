using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Data
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public bool Done { get; set; }
        public bool Deleted { get; set; }

        public override string ToString()
        {
            return Title;
        }
    }
}
