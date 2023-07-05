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
            clbTodo.ItemCheck -= clbTodo_ItemCheck_1;
            clbTodo.Items.Clear();
            foreach (var item in db.TodoItems.Where(x => !x.Deleted).OrderBy(x => x.Done))
            {
                clbTodo.Items.Add(item, item.Done);

            }

            clbTodo.ItemCheck += clbTodo_ItemCheck_1;
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
                BeginInvoke(TodolariListele); // checklendikten sonra çalýþtýrýyor. checklist box iþini bitirdikten sonra çalýþýyor. 

            }
        }
        private void btnSil_Click(object sender, EventArgs e)
        {
            if (clbTodo.SelectedItems.Count < 0)
                return;

            TodoItem silinecek = (TodoItem)clbTodo.SelectedItem;
            db.TodoItems.Remove(silinecek);
            db.SaveChanges();
            TodolariListele();

            // CHANGE TRACKER YÖNTEMÝ ÝLE CONTEXT ÝÇÝNDE SAVE CHANGES METODUNU EZDÝK VE SÝLÝNENLERÝ UNCAHNGED ÞEKLÝNDE GÜNCELLEDÝK.
            // LÝSTELE METODUNDA DELETED ALANLARI FALSE OLANLARI GETÝRDÝK.


        }


    }
}
