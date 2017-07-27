using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Skeleton.ServiceReferenceSkeleton;

namespace Skeleton
{
    public partial class FormMain : Form
    {
        ServiceSkeletonClient cl = new ServiceSkeletonClient();
        private List<tblSkeleton> MyItemList { get; set; }
        private tblSkeleton MySkeletonItem { get; set; }

        public FormMain()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            var itemName = txtItemAdd.Text;
            var itemCode = txtCodeAdd.Text;

            tblSkeleton tSkeleton = new tblSkeleton();
            tSkeleton.Name = itemName;
            tSkeleton.Code = Convert.ToInt32(itemCode);

            if (cl.AddItem(tSkeleton) == true)
            {
                ClearAddItems();
                lblStatus.Text = "Added item " + itemName + " with code " + itemCode;
            }
            else
            {
                MessageBox.Show("Error in adding item.");
            }
        }

        private void ClearAddItems()
        {
            txtCodeAdd.Text = "";
            txtItemAdd.Text = "";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            listBoxSearch.Items.Clear();

            string itemSearchName = txtSearch.Text;

            MyItemList = cl.GetItems(itemSearchName).ToList();

            foreach (var item in MyItemList)
            {
                listBoxSearch.Items.Add(item.Name);
            }

            lblStatus.Text = "Found " + MyItemList.Count + " items on the list";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string putName = txtItemUpdate.Text;
            int putCode = Convert.ToInt32(txtCodeUpdate.Text);

            tblSkeleton tSkelUpdate = new tblSkeleton();
            tSkelUpdate.id = MySkeletonItem.id;
            tSkelUpdate.Name = putName;
            tSkelUpdate.Code = putCode;
            
            if (cl.UpdateItem(tSkelUpdate) == true)
            {
                lblStatus.Text = "Updated item " + putName + " with code " + putCode;
                ClearUpdateItems();
            }
            else
            {
                MessageBox.Show("Error in updating item");
            }
        }

        private void ClearUpdateItems()
        {
            txtCodeUpdate.Text = "";
            txtItemUpdate.Text = "";
        }

        private void listBoxSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySkeletonItem = MyItemList.Find(x => x.Name == (String)listBoxSearch.SelectedItem);

            txtItemUpdate.Text = MySkeletonItem.Name;
            txtCodeUpdate.Text = MySkeletonItem.Code.ToString();
        }
    }
}
