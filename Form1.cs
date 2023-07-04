using Microsoft.EntityFrameworkCore;
using System.Windows.Forms;
using ToDoList.Data;

namespace ToDoList
{
    public partial class Form1 : Form
    {
        UygulamaDbContext db = new UygulamaDbContext();

        public Form1()
        {
            //1.Yapýlma Durumunu Güncelleme
            //2.Seçileni Kalýcý Silme
            //3.Ýkinci adýmýndan vazgeçip seçileni
            //"ChangeTracker" kullanarak yumuþak silme
            //4.Listele metodunda sadece Deleted alaný false olanlarý listeleme

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


        private void clbTodo_ItemCheck_1(object sender, ItemCheckEventArgs e)
        {
            TodoItem secili = (TodoItem)clbTodo.SelectedItem;

            if (secili == null)
                return;
            else
            {

                if (secili.Done == false)
                    secili.Done = true;
                else
                    secili.Done = false;

                db.SaveChanges();
                TodolariListele();
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (clbTodo.SelectedItems.Count < 0)
                return;

            TodoItem silinecek = (TodoItem)clbTodo.SelectedItem;
            db.TodoItems.Remove(silinecek);
            //db.SaveChanges();
            //TodolariListele();

            // CHANGE TRACKER YÖNTEMÝ

            foreach (var item in db.ChangeTracker.Entries())
            {
                TodoItem silinecekCT = (TodoItem)item.Entity;

                if (item.State == EntityState.Deleted)
                {
                    silinecekCT.Deleted = true;
                    silinecekCT.Done = false;
                    
                    Listele();
                    
                }

            }

        }

        private void Listele()
        {
            foreach (var item in db.TodoItems)
            {
                if (item.Deleted == true)
                    lstDeleted.Items.Add(item.Title);
            }
        }
    }
}