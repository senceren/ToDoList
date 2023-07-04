using System.Windows.Forms;
using ToDoList.Data;

namespace ToDoList
{
    public partial class Form1 : Form
    {
        UygulamaDbContext db = new UygulamaDbContext();

        public Form1()
        {
            //1.Yap�lma Durumunu G�ncelleme
            //2.Se�ileni Kal�c� Silme
            //3.�kinci ad�m�ndan vazge�ip se�ileni
            //"ChangeTracker" kullanarak yumu�ak silme
            //4.Listele metodunda sadece Deleted alan� false olanlar� listeleme

            InitializeComponent();
            TodolariListele();

        }

        private void TodolariListele()
        {
            clbTodo.Items.Clear();
            foreach (var item in db.TodoItems.OrderBy(x => x.Done))
            {
                clbTodo.Items.Add(item, item.Done);
            }


        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text.Trim();

            if (title == "")
                return;

            TodoItem newItem = new TodoItem() { Title = title, Done = false };
            db.TodoItems.Add(newItem);
            db.SaveChanges();

            TodolariListele();

        }

        private void clbTodo_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            
        }
    }
}