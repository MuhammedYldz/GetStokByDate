﻿using DevExpress.XtraGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _12MTestStokProject
{
    public partial class Form1 : Form
    {
        DataAccess da = new DataAccess();
        public Form1()
        {
            InitializeComponent();

            // This line of code is generated by Data Source Configuration Wizard
            // Uncomment next line to set the total number of data records stored within your source
            // unboundSource1.SetRowCount(42);
            // This line of code is generated by Data Source Configuration Wizard
            this.unboundSource1.ValueNeeded += unboundSource1_ValueNeeded;
            // This line of code is generated by Data Source Configuration Wizard
            this.unboundSource1.ValuePushed += unboundSource1_ValuePushed;
        }

        public List<DataInfoModel> GetData()
        {
            int baslangıcTarih = Convert.ToInt32(dateTimePicker1.Value.ToOADate());
            int bitisTarih = Convert.ToInt32(dateTimePicker2.Value.ToOADate());

            List<DataInfoModel> info = da.GetInfo(baslangıcTarih, bitisTarih);
            return info;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<DataInfoModel> info = GetData();

            foreach (var item in info)
            {

                gridView1.AddNewRow();

                gridView1.SetRowCellValue(GridControl.NewItemRowHandle, gridView1.Columns["SıraNo"], item.SıraNo);
                gridView1.SetRowCellValue(GridControl.NewItemRowHandle, gridView1.Columns["EvrakNo"], item.EvrakNo);
                gridView1.SetRowCellValue(GridControl.NewItemRowHandle, gridView1.Columns["IslemTur"], item.IslemTur);
                gridView1.SetRowCellValue(GridControl.NewItemRowHandle, gridView1.Columns["Tarih"], item.Tarih);
                gridView1.SetRowCellValue(GridControl.NewItemRowHandle, gridView1.Columns["GirisMiktar"], item.GirisMiktar);
                gridView1.SetRowCellValue(GridControl.NewItemRowHandle, gridView1.Columns["CıkısMiktar"], item.CıkısMiktar);
                if (item.IslemTur == "Giriş")
                {
                    gridView1.SetRowCellValue(GridControl.NewItemRowHandle, gridView1.Columns["StokMiktar"], item.Miktar + item.GirisMiktar);
                }
                else { gridView1.SetRowCellValue(GridControl.NewItemRowHandle, gridView1.Columns["StokMiktar"], item.Miktar - item.CıkısMiktar); }

            }
        }

        // This event is generated by Data Source Configuration Wizard
        void unboundSource1_ValueNeeded(object sender, DevExpress.Data.UnboundSourceValueNeededEventArgs e)
        {
            
        }

        // This event is generated by Data Source Configuration Wizard
        void unboundSource1_ValuePushed(object sender, DevExpress.Data.UnboundSourceValuePushedEventArgs e)
        {
            // Handle this event to save modified data back to your data source
            // something = e.Value; /* TODO: Propagate the value into the storage.*/
        }
    }
}