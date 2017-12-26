using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ASRSStorManage.Presenter;
using AsrsModel;

namespace ASRSStorManage.View
{
    public partial class MultiGsEnabledSet : Form
    {
        public bool IsModify = false;
        StoragePresenter presenter=null;
        private string houseName = "";
        private int rowth = 1;
        public MultiGsEnabledSet(string houseName, int rowth, StoragePresenter presenter, List<string> colList, List<string> layerList)
        {
            InitializeComponent();
            this.Text = houseName +"-"+rowth +"排-货位批量设置";
            this.presenter = presenter;
            this.houseName = houseName;
            this.rowth = rowth;
            IniLayerList(layerList);
            IniLayerListArea(layerList);
            IniColList(colList);
            IniColListArea(colList);
            IniHouseAreaList();
        }

        private void IniLayerListArea( List<string> layerList)
        {
            this.cb_LayerListArea.Items.Clear();
            for (int i = 0; i < layerList.Count; i++)
            {
                this.cb_LayerListArea.Items.Add(layerList[i]);

            }
            if (this.cb_LayerListArea.Items.Count > 0)
            {
                this.cb_LayerListArea.SelectedIndex = 0;
            }
        }
        private void IniLayerList( List<string> layerList)
        {
            this.cb_LayerList.Items.Clear();
            for(int i=0;i<layerList.Count;i++)
            {
                this.cb_LayerList.Items.Add(layerList[i]);

            }
             if( this.cb_LayerList.Items.Count>0)
             {
                 this.cb_LayerList.SelectedIndex = 0;
             }
        }

        private void IniColListArea(List<string> colList)
        {
            this.cb_ColListSTArea.Items.Clear();
            this.cb_ColListEDArea.Items.Clear();

            for (int i = 0; i < colList.Count; i++)
            {
                this.cb_ColListSTArea.Items.Add(colList[i]);
                this.cb_ColListEDArea.Items.Add(colList[i]);
            }
            if (this.cb_ColListSTArea.Items.Count > 0)
            {
                this.cb_ColListSTArea.SelectedIndex = 0;

            }
            if (this.cb_ColListEDArea.Items.Count > 0)
            {
                this.cb_ColListEDArea.SelectedIndex = 0;
            }

        }
        private void IniHouseAreaList()
        {
            this.cb_HouseArea.Items.Clear();
            for(int i=0;i<Enum.GetNames(typeof(EnumLogicArea)).Length;i++)
            {
                string areaName = Enum.GetNames(typeof(EnumLogicArea))[i];
                this.cb_HouseArea.Items.Add(areaName);
            }
            if(this.cb_HouseArea.Items.Count>0)
            {
                this.cb_HouseArea.SelectedIndex = 0;
            }
        }

        private void IniColList(List<string> colList)
        {
            this.cb_ColSTList.Items.Clear();
            this.cb_ColEDList.Items.Clear();
            for (int i = 0; i < colList.Count; i++)
            {
                this.cb_ColSTList.Items.Add(colList[i]);
                this.cb_ColEDList.Items.Add(colList[i]);

            }
            if (this.cb_ColSTList.Items.Count > 0)
            {
                this.cb_ColSTList.SelectedIndex = 0;
            }
            if (this.cb_ColEDList.Items.Count > 0)
            {
                this.cb_ColEDList.SelectedIndex = 0;
            }
        }
        private void bt_UseGs_Click(object sender, EventArgs e)
        {
           
            if(this.rb_singleCol.Checked == true)
            {
                int stCol = int.Parse(this.cb_ColSTList.Text);
                int edCol = int.Parse(this.cb_ColEDList.Text);
                if(edCol<stCol)
                {
                    MessageBox.Show("您的起止列设置错误！", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
               
                }

                this.presenter.UseOrForbitSingleColGs(this.houseName, this.rowth, stCol, edCol,true);
            }
            else if(this.rb_SingleLayer.Checked == true)
            {
                int layerth = int.Parse(this.cb_LayerList.Text);
                this.presenter.UseOrForbitSingleLayerGs(this.houseName, this.rowth, layerth, true);
            }
            this.IsModify = true;
             
        }

        private void bt_GsFobit_Click(object sender, EventArgs e)
        {
          
            if (this.rb_singleCol.Checked == true)
            {
                int stCol = int.Parse(this.cb_ColSTList.Text);
                int edCol = int.Parse(this.cb_ColEDList.Text);
                if (edCol < stCol)
                {
                    MessageBox.Show("您的起止列设置错误！", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;

                }

                this.presenter.UseOrForbitSingleColGs(this.houseName, this.rowth, stCol,edCol, false);
            }
            else if (this.rb_SingleLayer.Checked == true)
            {
                int layerth = int.Parse(this.cb_LayerList.Text);
                this.presenter.UseOrForbitSingleLayerGs(this.houseName, this.rowth, layerth, false);
            }
            this.IsModify = true;
           
        }

        private void bt_Cancel_Click(object sender, EventArgs e)
        {
            this.IsModify = false;
            this.Close();
        }
 

        private void bt_AreaSet_Click(object sender, EventArgs e)
        {
            //if(this.rb_SingleGsArea.Checked == true)
            //{
            //    this.presenter.SetSingleGsArea(this.houseName, this.tb_GsName.Text,this.cb_HouseArea.Text);
            //}
            //else
         
            if(this.rb_SingleColArea.Checked == true)
            {
                int startCol = int.Parse(this.cb_ColListSTArea.Text);
                int endCol = int.Parse(this.cb_ColListEDArea.Text);
                if (endCol < startCol)
                {
                    MessageBox.Show("您的起止列设置错误！", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                this.presenter.SetSingleColArea(this.houseName, this.rowth, startCol,endCol, this.cb_HouseArea.Text);
            }
            else if(this.rb_SingleLayerArea.Checked == true)
            {
                this.presenter.SetSingleLayerArea(this.houseName,this.rowth, int.Parse(this.cb_LayerListArea.Text),this.cb_HouseArea.Text);
            }
        }
    }
}
