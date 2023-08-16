using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ListviewExample
{
    public partial class Form1 : Form
    {
        ListView listView1;
        ImageList imageList;

        public Form1()
        {
            InitializeComponent();

            // Создаем новый ListView
            listView1 = new ListView();

            // Создаем новый ImageList для иконок
            imageList = new ImageList();
            imageList.ImageSize = new Size(24, 24); // Устанавливаем размер иконок
            listView1.SmallImageList = imageList;

            // Конфигурируем свойства ListView
            listView1.Bounds = new Rectangle(new Point(10, 10), new Size(300, 200));
            listView1.View = View.Details;
            listView1.LabelEdit = true;
            listView1.AllowColumnReorder = true;
            listView1.CheckBoxes = true;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.Sorting = SortOrder.Ascending;

            // Создаем столбцы для ListView
            listView1.Columns.Add("Иконка", 50, HorizontalAlignment.Left);
            listView1.Columns.Add("Название", 150, HorizontalAlignment.Left);
            listView1.Columns.Add("Цена (ГРН)", 80, HorizontalAlignment.Right);

            // Создаем элементы для ListView
            ListViewItem item1 = CreateWishlistItem(Properties.Resources._1, "Премиальные часы", 2500);
            ListViewItem item2 = CreateWishlistItem(Properties.Resources._2, "Отпуск мечты", 10000);
            ListViewItem item3 = CreateWishlistItem(Properties.Resources._3, "Мощная видеокарта", 8000);
            ListViewItem item4 = CreateWishlistItem(Properties.Resources._4, "Беговая дорожка", 5000);
            ListViewItem item5 = CreateWishlistItem(Properties.Resources._5, "Квадракоптер", 4000);

            // Добавляем элементы в ListView
            listView1.Items.AddRange(new ListViewItem[] { item1, item2, item3, item4, item5 });

            // Добавляем ListView на форму
            this.Controls.Add(listView1);

            Width = 350;
            Height = 250;
        }

        private ListViewItem CreateWishlistItem(Image icon, string itemName, decimal price)
        {
            ListViewItem item = new ListViewItem();

            // Добавляем изображение в ImageList
            imageList.Images.Add(icon);

            item.ImageIndex = imageList.Images.Count - 1; // Устанавливаем индекс изображения
            item.SubItems.Add(itemName); // Устанавливаем название предмета
            item.SubItems.Add(price.ToString("N2")); // Устанавливаем цену в формате "N2"

            return item;
        }
    }
}