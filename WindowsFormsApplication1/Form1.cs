using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form


    {



        DataTable dtCustomer = new DataTable();
        DataTable dtjpMembers = new DataTable();

        string connectionstring = null;
        string sql = null;
        SqlConnection connection;
        SqlCommand command;
        SqlDataReader datareader;


        double SmoothieTotalPrice, BowlTotalPrice, ShooterTotalPrice;
        double WaterfallMelonSmallPrice = 5.08, WaterfallMelonLargePrice = 9.44, JavaJavaSmallPrice = 4.15, JavaJavaLargePrice = 7.57, TheClassicSmallPrice = 4.08, TheClassicLargePrice = 7.44, TheTropicsSmallPrice = 6.64, TheTropicsLargePrice = 12.56, TheGreenGoblinSmallPrice = 6.90, TheGreenGoblinLargePrice = 13.08, GiveMeABoostSmallPrice = 11.13, GiveMeABoostLargePrice = 18.93, SourCravingSmallPrice = 5.34, SourCravingLargePrice = 9.96;
        double BowlofMelonSmallPrice = 4.23, BowlofMelonLargePrice = 8.45, IslandMedleySmallPrice = 6.70, IslandMedleyLargePrice = 13.39, CreamAndCrunchSmallPrice = 4.00, CreamAndCrunchyLargePrice = 8.01, TheRedHeadSmallPrice = 2.93, TheRedHeadLargePrice = 5.85;
        double WatermelonShotPrice = 2.28, CoffeeShotPrice = 1.69, StrawberryShotPrice = 2.28, BlueberryShotPrice = 2.60, ApricotShotPrice = 3.58, CherryShotPrice = 3.58, PeachShotPrice = 2.93, PineappleShotPrice = 3.97, BananaShotPrice = 2.05, MangoShotPrice = 2.28, KiwiShotPrice = 1.76, DragonFruitShotPrice = 3.25;
        double A1Price = 6, A2Price = 12, A3Price = 24, A4Price = 36;

        double PreTaxTotal, SalesTax, Total, InventoryPreTax, InventorySalesTax, InventoryTotal;



        int SmoothieQty, BowlQty, ShooterQty, InventoryQty;

        private void richTextBoxOrderSummary_TextChanged(object sender, EventArgs e)
        {

        }

        String[] Gender = { "Female", "Male", "Other", "Decline to Answer" };

        public Form1()
        {

            InitializeComponent();
        }



        private void mainMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowMainMenu();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            ShowMainMenu();
             Width = 630;
            Height = 540;

            ///////////////////////////////

            connectionstring = "Data Source=essql1.Walton.uark.edu;Initial Catalog=ISYS4283F1955; User ID=ISYS4283F1955;Password=FM37dog$";
            connection = new SqlConnection(connectionstring);
            sql = "SELECT Phone, Name FROM Customer";
            connection.Open();

            command = new SqlCommand(sql, connection);
            datareader = command.ExecuteReader();
            while (datareader.Read())
            {
                drpDownPhoneNum.Items.Add(datareader[0].ToString());
            }

            datareader.Close();
            command.Dispose();
            connection.Close();



            //fills the gender dropdown
            for (int i = 0; i < Gender.Length; i++)
            {
                drpDownJPGender.Items.Add(Gender[i]);
            }

            /////////////////////////////////////

            /////////////////////////////////////
            connectionstring = "Data Source=essql1.Walton.uark.edu;Initial Catalog=ISYS4283F1955; User ID=ISYS4283F1955;Password=FM37dog$";
            connection = new SqlConnection(connectionstring);
            sql = "SELECT item FROM Item WHERE Type = 'Smoothie'";
            connection.Open();

            command = new SqlCommand(sql, connection);
            datareader = command.ExecuteReader();
            while (datareader.Read())
            {
                drpDownSmoothies.Items.Add(datareader[0].ToString());
            }

            datareader.Close();
            command.Dispose();
            connection.Close();

            ////////////////////////////////////
            connectionstring = "Data Source=essql1.Walton.uark.edu;Initial Catalog=ISYS4283F1955; User ID=ISYS4283F1955;Password=FM37dog$";
            connection = new SqlConnection(connectionstring);
            sql = "SELECT item FROM Item WHERE Type = 'Bowl'";
            connection.Open();

            command = new SqlCommand(sql, connection);
            datareader = command.ExecuteReader();
            while (datareader.Read())
            {
                drpDownBowls.Items.Add(datareader[0].ToString());
            }

            datareader.Close();
            command.Dispose();
            connection.Close();

            ///////////////////////////////////////

            connectionstring = "Data Source=essql1.Walton.uark.edu;Initial Catalog=ISYS4283F1955; User ID=ISYS4283F1955;Password=FM37dog$";
            connection = new SqlConnection(connectionstring);
            sql = "SELECT item FROM Item WHERE Type = 'Shooter'";
            connection.Open();

            command = new SqlCommand(sql, connection);
            datareader = command.ExecuteReader();
            while (datareader.Read())
            {
                drpDownShooters.Items.Add(datareader[0].ToString());
            }

            datareader.Close();
            command.Dispose();
            connection.Close();
            //////////////

            connectionstring = "Data Source=essql1.Walton.uark.edu;Initial Catalog=ISYS4283F1955; User ID=ISYS4283F1955;Password=FM37dog$";
            connection = new SqlConnection(connectionstring);
            sql = "SELECT Inventory_Name FROM Inventory";
            connection.Open();

            command = new SqlCommand(sql, connection);
            datareader = command.ExecuteReader();
            while (datareader.Read())
            {
                drpDownInventory.Items.Add(datareader[0].ToString());
            }

            datareader.Close();
            command.Dispose();
            connection.Close();

            //////////////////////////////////////

            ////////////////////////////////////////////
        }

          private void bttnAddCust_Click(object sender, EventArgs e)
        {

        

         //INSERTINTO Customer(name, phone) VALUES('John', '4795551212')"


           if (Walton_DB.ExecSqlString("INSERT INTO Customer (name, phone) VALUES ('" + txtCustomerName.Text + "','" + txtRewardsTelephone.Text + "')"))
          {
             MessageBox.Show("Customer Added!");
          }



}

        //Docks the Main Menu
    private void ShowMainMenu()
        {
            pnlMainMenu.Visible = true;
            pnlMainMenu.Dock = DockStyle.Fill;

            pnlReports.Visible = false;
            pnlJPMembers.Visible = false;
            pnlExpenses.Visible = false;
            pnlOrderInventory.Visible = false;


        }

        private void jPMembersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowJPMembersMenu();
        }

        private void ShowReports()
        {
            pnlReports.Visible = true;

            pnlReports.Dock = DockStyle.Fill;

            pnlMainMenu.Visible = false;
            pnlJPMembers.Visible = false;
            pnlOrderInventory.Visible = false;
            pnlExpenses.Visible = false;

        }

        private void ReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowReports();

        }
        //Docks The Juicy Perk Member Panel
        private void ShowJPMembersMenu()
        {

            pnlJPMembers.Visible = true;
            pnlJPMembers.Dock = DockStyle.Fill;
            pnlReports.Visible = false;

            pnlMainMenu.Visible = false;
            pnlOrderInventory.Visible = false;
            pnlExpenses.Visible = false;
        }

        private void ShowExpenses()
        {
            pnlExpenses.Visible = true;
            pnlExpenses.Dock = DockStyle.Fill;
            pnlReports.Visible = false;

            pnlMainMenu.Visible = false;
            pnlOrderInventory.Visible = false;
            pnlJPMembers.Visible = false;
        }

        private void expensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowExpenses();
        }




        private void ShowOrderInventory()
        {
            pnlOrderInventory.Visible = true;
            pnlOrderInventory.Dock = DockStyle.Fill;

            pnlMainMenu.Visible = false;
            pnlReports.Visible = false;
            pnlJPMembers.Visible = false;
            pnlExpenses.Visible = false;
        
         

            sql = "SELECT Inventory_Id, Inventory_Name, Package_Amount, Price, Reorder_Level FROM Inventory";

            DataTable dtCustomerInfo = new DataTable();

            Walton_DB.FillDataTable_ViaSql(ref dtCustomerInfo, sql);
            dataGridViewInventory.DataSource = dtCustomerInfo;
            dataGridViewInventory.Refresh();


        }
        private void inventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowOrderInventory();


           
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bttnLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            Inventory inventoryPrompt = new Inventory();
            inventoryPrompt.ShowDialog();

            Application.Exit();
        }



        private void pnlJPMembers_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbPhone_SelectedIndexChanged(object sender, EventArgs e)
        {

            sql = "SELECT Customer_Id, name, phone FROM Customer";

            DataTable dtCustomerInfo = new DataTable();

            Walton_DB.FillDataTable_ViaSql(ref dtCustomerInfo, sql);
            dataGridView2.DataSource = dtCustomerInfo;
            dataGridView2.Refresh();



        }

        private void RefreshStudentPhoneNumber()
        {


        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void bttnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bttnClearJP_Click(object sender, EventArgs e)
        {
            txtJPCustomerName.Text = "";

            txtJPCityAddress.Text = "";
            txtJPDOB.Text = "";
            txtJPPhoneNumb.Text = "";
            txtJPStreetAddress.Text = "";
            txtJPPostalCode.Text = "";
            drpDownJPGender.SelectedIndex = -1;
            // drpDownJPStateAddress.SelectedIndex = -1;

        }





        private void dropDownSmoothies_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void drpDownBowls_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void drpDownShooters_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bttnAddCustJP_Click(object sender, EventArgs e)
        {
            


            string Gender = "";
            Gender = drpDownJPGender.ToString();

            string CustomerName = "";
            CustomerName = txtJPCustomerName.Text;
            string Phone = "";
            Phone = txtJPPhoneNumb.Text;
            string Street = "";
            Street = txtJPStreetAddress.Text;
            string City = "";
            City = txtJPCityAddress.Text;
            string PostalCode = "";
            PostalCode = txtJPPostalCode.Text;


            //if (txtJPDOB.Text == "")
            //{
            //    MessageBox.Show("Please Enter Date of Birth MM/DD/YYYY");
            //    return;
            //}

            //if (CustomerName.Trim() == "")
            //{
            //    MessageBox.Show("You Must Enter A Name!");
            //    return;
            //}


            //else if (Phone.Trim() == "")
            //{
            //    MessageBox.Show("You Must Enter A Number!");
            //    return;
            //}

            //else if (drpDownJPGender.SelectedIndex != -1)
            //{
            //    Gender = drpDownJPGender.Text;
            //}

            //else if (drpDownJPGender.SelectedIndex == -1)
            //{
            //    MessageBox.Show("You Must Select A Gender");
            //    return;
            //}

            //else if (Street.Trim() == "")
            //{
            //    MessageBox.Show("You Must Enter Your Street Address");
            //    return;
            //}

            //else if (City.Trim() == "")
            //{
            //    MessageBox.Show("You Must Enter A City!");
            //    return;
            //}

            //else if (PostalCode.Trim() == "")
            //{
            //    MessageBox.Show("You Must Enter A Postal Code!");
            //    return;
            //}

            
            if (Walton_DB.ExecSqlString("INSERT INTO jpMembers (name, phone, birthday, gender, street, city, zip ) VALUES ('" + txtJPCustomerName.Text + "','" + txtJPPhoneNumb.Text + "' , '" + txtJPDOB.Text + "', '" + drpDownJPGender.SelectedItem.ToString() + "' , '" + txtJPStreetAddress.Text + "', '" + txtJPCityAddress.Text + "', '" + txtJPPostalCode.Text + "')"))
            {
                MessageBox.Show("Juicy Perks Member Added");
               
                return;
                


            }
            

        }


        //////////////////////////////////////////////////////


        private void drpDownJPGender_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bttnInventoryRprt_Click(object sender, EventArgs e)
        {

            sql = "SELECT InventoryOrderNumber, Inventory_Name, Qty_Ordered, Date_Ordered FROM InventoryOrderingLog";

            DataTable dtCustomerInfo = new DataTable();

            Walton_DB.FillDataTable_ViaSql(ref dtCustomerInfo, sql);
            dataGridView3.DataSource = dtCustomerInfo;
            dataGridView3.Refresh();
        }

        private void bttnExpenseRprt_Click(object sender, EventArgs e)
        {
            {

                sql = "SELECT Expense_Id, eDesc, expseCost FROM Expense";

                DataTable dtCustomerInfo = new DataTable();

                Walton_DB.FillDataTable_ViaSql(ref dtCustomerInfo, sql);
                dataGridView3.DataSource = dtCustomerInfo;
                dataGridView3.Refresh();
            }
        }

        private void bttnSalesRprt_Click(object sender, EventArgs e)
        {
            {

                sql = "SELECT Payment_Id, aDue, aPaid, customer FROM Payment";

                DataTable dtCustomerInfo = new DataTable();

                Walton_DB.FillDataTable_ViaSql(ref dtCustomerInfo, sql);
                dataGridView3.DataSource = dtCustomerInfo;
                dataGridView3.Refresh();
            }
        }

        private void bttnPandLRprt_Click(object sender, EventArgs e)
        {

        }

        private void btnList_Click(object sender, EventArgs e)
        {
            
            sql = "SELECT jpMember_Id, name, birthday, city, email, gender, phone, postal, street, zip FROM jpMembers";

            DataTable dtjpMembers = new DataTable();

            Walton_DB.FillDataTable_ViaSql(ref dtjpMembers, sql);

            dataGridView1.DataSource = dtjpMembers;
            dataGridView1.Refresh();

           

        }

        private void txtBoxSmoothieQty_TextChanged(object sender, EventArgs e)
        {

        }

        private void bttnAddToOrder_Click(object sender, EventArgs e)
        {

            int.TryParse(txtBoxSmoothieQty.Text, out SmoothieQty);
            int.TryParse(txtBoxBowlQty.Text, out BowlQty);
            int.TryParse(txtBoxShootersQty.Text, out ShooterQty);

            if (drpDownSmoothies.SelectedIndex == 0)
            {
                SmoothieTotalPrice = WaterfallMelonSmallPrice * (double)SmoothieQty;
            }
            else if (drpDownSmoothies.SelectedIndex == 1)
            {
                SmoothieTotalPrice = WaterfallMelonLargePrice * (double)SmoothieQty;
            }
            else if (drpDownSmoothies.SelectedIndex == 2)
            {
                SmoothieTotalPrice = JavaJavaSmallPrice * (double)SmoothieQty;
            }
            else if (drpDownSmoothies.SelectedIndex == 3)
            {
                SmoothieTotalPrice = JavaJavaLargePrice * (double)SmoothieQty;
            }
            else if (drpDownSmoothies.SelectedIndex == 4)
            {
                SmoothieTotalPrice = TheClassicSmallPrice * (double)SmoothieQty;
            }
            else if (drpDownSmoothies.SelectedIndex == 5)
            {
                SmoothieTotalPrice = TheClassicLargePrice * (double)SmoothieQty;
            }
            else if (drpDownSmoothies.SelectedIndex == 6)
            {
                SmoothieTotalPrice = TheTropicsSmallPrice * (double)SmoothieQty;
            }
            else if (drpDownSmoothies.SelectedIndex == 7)
            {
                SmoothieTotalPrice = TheTropicsLargePrice * (double)SmoothieQty;
            }
            else if (drpDownSmoothies.SelectedIndex == 8)
            {
                SmoothieTotalPrice = TheGreenGoblinSmallPrice * (double)SmoothieQty;
            }
            else if (drpDownSmoothies.SelectedIndex == 9)
            {
                SmoothieTotalPrice = TheGreenGoblinLargePrice * (double)SmoothieQty;
            }
            else if (drpDownSmoothies.SelectedIndex == 10)
            {
                SmoothieTotalPrice = GiveMeABoostSmallPrice * (double)SmoothieQty;
            }
            else if (drpDownSmoothies.SelectedIndex == 11)
            {
                SmoothieTotalPrice = GiveMeABoostLargePrice * (double)SmoothieQty;
            }
            else if (drpDownSmoothies.SelectedIndex == 12)
            {
                SmoothieTotalPrice = SourCravingSmallPrice * (double)SmoothieQty;
            }
            else if (drpDownSmoothies.SelectedIndex == 13)
            {
                SmoothieTotalPrice = SourCravingLargePrice * (double)SmoothieQty;
            }
            else
            {
                SmoothieTotalPrice = 0;
            }

            if (drpDownBowls.SelectedIndex == 0)
            {
                BowlTotalPrice = BowlofMelonSmallPrice * (double)BowlQty;
            }
            else if (drpDownBowls.SelectedIndex == 1)
            {
                BowlTotalPrice = BowlofMelonLargePrice * (double)BowlQty;
            }
            else if (drpDownBowls.SelectedIndex == 2)
            {
                BowlTotalPrice = IslandMedleySmallPrice * (double)BowlQty;
            }
            else if (drpDownBowls.SelectedIndex == 3)
            {
                BowlTotalPrice = IslandMedleyLargePrice * (double)BowlQty;
            }
            else if (drpDownBowls.SelectedIndex == 4)
            {
                BowlTotalPrice = CreamAndCrunchSmallPrice * (double)BowlQty;
            }
            else if (drpDownBowls.SelectedIndex == 5)
            {
                BowlTotalPrice = CreamAndCrunchyLargePrice * (double)BowlQty;
            }
            else if (drpDownBowls.SelectedIndex == 6)
            {
                BowlTotalPrice = TheRedHeadSmallPrice * (double)BowlQty;
            }
            else if (drpDownBowls.SelectedIndex == 7)
            {
                BowlTotalPrice = TheRedHeadLargePrice * (double)BowlQty;
            }
            else
            {
                BowlTotalPrice = 0;
            }

            if (drpDownShooters.SelectedIndex == 0)
            {
                ShooterTotalPrice = WatermelonShotPrice * (double)ShooterQty;
            }
            else if (drpDownShooters.SelectedIndex == 1)
            {
                ShooterTotalPrice = CoffeeShotPrice * (double)ShooterQty;
            }
            else if (drpDownShooters.SelectedIndex == 2)
            {
                ShooterTotalPrice = StrawberryShotPrice * (double)ShooterQty;
            }
            else if (drpDownShooters.SelectedIndex == 3)
            {
                ShooterTotalPrice = BlueberryShotPrice * (double)ShooterQty;
            }
            else if (drpDownShooters.SelectedIndex == 4)
            {
                ShooterTotalPrice = ApricotShotPrice * (double)ShooterQty;
            }
            else if (drpDownShooters.SelectedIndex == 5)
            {
                ShooterTotalPrice = CherryShotPrice * (double)ShooterQty;
            }
            else if (drpDownShooters.SelectedIndex == 6)
            {
                ShooterTotalPrice = PeachShotPrice * (double)ShooterQty;
            }
            else if (drpDownShooters.SelectedIndex == 7)
            {
                ShooterTotalPrice = PineappleShotPrice * (double)ShooterQty;
            }
            else if (drpDownShooters.SelectedIndex == 8)
            {
                ShooterTotalPrice = BananaShotPrice * (double)ShooterQty;
            }
            else if (drpDownShooters.SelectedIndex == 9)
            {
                ShooterTotalPrice = MangoShotPrice * (double)ShooterQty;
            }
            else if (drpDownShooters.SelectedIndex == 10)
            {
                ShooterTotalPrice = KiwiShotPrice * (double)ShooterQty;
            }
            else if (drpDownShooters.SelectedIndex == 11)
            {
                ShooterTotalPrice = DragonFruitShotPrice * (double)ShooterQty;
            }
            else
            {
                ShooterTotalPrice = 0;
            }

            richTextBoxOrderSummary.Text = "You have ordered " + txtBoxSmoothieQty.Text.ToString() + " of " + drpDownSmoothies.SelectedItem.ToString() + " -" + SmoothieTotalPrice.ToString("C") + ", \n" + txtBoxBowlQty.Text.ToString() + " of " + drpDownBowls.SelectedItem.ToString() + " -" + BowlTotalPrice.ToString("C") + ", and \n" + txtBoxShootersQty.Text.ToString() + " of " + drpDownShooters.SelectedItem.ToString() + " -" + ShooterTotalPrice.ToString("C") + ".";

            PreTaxTotal = (double)SmoothieTotalPrice + (double)BowlTotalPrice + (double)ShooterTotalPrice;
            SalesTax = PreTaxTotal * 0.001;
            Total = PreTaxTotal + SalesTax;

            txtBoxPreTaxTot.Text = PreTaxTotal.ToString("C");
            txtBoxSalesTaxTotal.Text = SalesTax.ToString("C");
            txtBoxRewardsFromOrder.Text = "$0.00";
            txtBoxTotal.Text = Total.ToString("C");
        }

        private void bttnAddRewards_Click(object sender, EventArgs e)
        {
            /////////////////////////////////////////////
            txtBoxPreTaxTot.Text = "";
            txtBoxSalesTaxTotal.Text = "";
            txtBoxRewardsFromOrder.Text = "";
            txtBoxTotal.Text = "";
            richTextBoxOrderSummary.Text = "";

            int.TryParse(txtBoxSmoothieQty.Text, out SmoothieQty);
            int.TryParse(txtBoxBowlQty.Text, out BowlQty);
            int.TryParse(txtBoxShootersQty.Text, out ShooterQty);
            double RewardsFromOrderTotal;

            PreTaxTotal = ((double)SmoothieTotalPrice + (double)BowlTotalPrice + (double)ShooterTotalPrice) * 0.9;

            SalesTax = PreTaxTotal * 0.001;
            Total = PreTaxTotal + SalesTax;
            RewardsFromOrderTotal = PreTaxTotal * .1;
            txtBoxPreTaxTot.Text = PreTaxTotal.ToString("C");
            txtBoxSalesTaxTotal.Text = SalesTax.ToString("C");
            txtBoxRewardsFromOrder.Text = RewardsFromOrderTotal.ToString("C");
            txtBoxTotal.Text = Total.ToString("C");

            richTextBoxOrderSummary.Text = "You have ordered " + SmoothieQty.ToString() + " of " + drpDownSmoothies.SelectedItem.ToString() + " -" + SmoothieTotalPrice.ToString("C") + ", \n" + BowlQty.ToString() + " of " + drpDownBowls.SelectedItem.ToString() + " -" + BowlTotalPrice.ToString("C") + ", and \n" + ShooterQty.ToString() + " of " + drpDownShooters.SelectedItem.ToString() + " -" + ShooterTotalPrice.ToString("C") + ". \n Rewards Added - 10% off";

            /////////////////////////////////////////////
        }

        private void bttnClearMenu_Click(object sender, EventArgs e)
        {
            txtBoxBowlQty.Text = "";
            txtBoxPreTaxTot.Text = "";
            txtBoxRewardsFromOrder.Text = "";
            txtBoxSalesTaxTotal.Text = "";
            txtBoxShootersQty.Text = "";
            txtBoxSmoothieQty.Text = "";
            txtBoxTotal.Text = "";
            txtCustomerName.Text = "";
            txtRewardsTelephone.Text = "";
            drpDownBowls.SelectedIndex = -1;
            drpDownShooters.SelectedIndex = -1;
            drpDownSmoothies.SelectedIndex = -1;
            drpDownPhoneNum.SelectedIndex = -1;
            richTextBoxOrderSummary.Text = "";

           
        }

        //Inventory Panel Code
        private void button1_Click(object sender, EventArgs e)
        {


            int.TryParse(txtBoxInvQty.Text, out InventoryQty);

            if(drpDownInventory.SelectedIndex == 0)
            {
                InventoryPreTax = A2Price * (double)InventoryQty;
            }
            else if (drpDownInventory.SelectedIndex == 1)
            {
                InventoryPreTax = A2Price * (double)InventoryQty;
            }
            else if (drpDownInventory.SelectedIndex == 2)
            {
                InventoryPreTax = A2Price * (double)InventoryQty;
            }
            else if (drpDownInventory.SelectedIndex == 3)
            {
                InventoryPreTax = A2Price * (double)InventoryQty;
            }
            else if (drpDownInventory.SelectedIndex == 4)
            {
                InventoryPreTax = A2Price * (double)InventoryQty;
            }
            else if (drpDownInventory.SelectedIndex == 5)
            {
                InventoryPreTax = A2Price * (double)InventoryQty;
            }
            else if (drpDownInventory.SelectedIndex == 6)
            {
                InventoryPreTax = A2Price * (double)InventoryQty;
            }
            else if (drpDownInventory.SelectedIndex == 7)
            {
                InventoryPreTax = A2Price * (double)InventoryQty;
            }
            else if (drpDownInventory.SelectedIndex == 8)
            {
                InventoryPreTax = A2Price * (double)InventoryQty;
            }
            else if (drpDownInventory.SelectedIndex == 9)
            {
                InventoryPreTax = A2Price * (double)InventoryQty;
            }
            else if (drpDownInventory.SelectedIndex == 10)
            {
                InventoryPreTax = A2Price * (double)InventoryQty;
            }
            else if (drpDownInventory.SelectedIndex == 11)
            {
                InventoryPreTax = A1Price * (double)InventoryQty;
            }
            else if (drpDownInventory.SelectedIndex == 12)
            {
                InventoryPreTax = A2Price * (double)InventoryQty;
            }
            else if (drpDownInventory.SelectedIndex == 13)
            {
                InventoryPreTax = A2Price * (double)InventoryQty;
            }
            else if (drpDownInventory.SelectedIndex == 14)
            {
                InventoryPreTax = A2Price * (double)InventoryQty;
            }
            else if (drpDownInventory.SelectedIndex == 15)
            {
                InventoryPreTax = A2Price * (double)InventoryQty;
            }
            else if (drpDownInventory.SelectedIndex == 16)
            {
                InventoryPreTax = A2Price * (double)InventoryQty;
            }
            else if (drpDownInventory.SelectedIndex == 17)
            {
                InventoryPreTax = A2Price * (double)InventoryQty;
            }
            else if (drpDownInventory.SelectedIndex == 18)
            {
                InventoryPreTax = A2Price * (double)InventoryQty;
            }
            else if (drpDownInventory.SelectedIndex == 19)
            {
                InventoryPreTax = A2Price * (double)InventoryQty;
            }
            else if (drpDownInventory.SelectedIndex == 20)
            {
                InventoryPreTax = A1Price * (double)InventoryQty;
            }
            else if (drpDownInventory.SelectedIndex == 21)
            {
                InventoryPreTax = A2Price * (double)InventoryQty;
            }
            else if (drpDownInventory.SelectedIndex == 22)
            {
                InventoryPreTax = A2Price * (double)InventoryQty;
            }
            else if (drpDownInventory.SelectedIndex == 23)
            {
                InventoryPreTax = A1Price * (double)InventoryQty;
            }
            else if (drpDownInventory.SelectedIndex == 24)
            {
                InventoryPreTax = A1Price * (double)InventoryQty;
            }
            else if (drpDownInventory.SelectedIndex == 25)
            {
                InventoryPreTax = A1Price * (double)InventoryQty;
            }
            else if (drpDownInventory.SelectedIndex == 26)
            {
                InventoryPreTax = A1Price * (double)InventoryQty;
            }
            else if (drpDownInventory.SelectedIndex == 27)
            {
                InventoryPreTax = A2Price * (double)InventoryQty;
            }
            else if (drpDownInventory.SelectedIndex == 28)
            {
                InventoryPreTax = A1Price * (double)InventoryQty;
            }
            else if (drpDownInventory.SelectedIndex == 29)
            {
                InventoryPreTax = A3Price * (double)InventoryQty;
            }
            else if (drpDownInventory.SelectedIndex == 30)
            {
                InventoryPreTax = A3Price * (double)InventoryQty;
            }
            else if (drpDownInventory.SelectedIndex == 31)
            {
                InventoryPreTax = A3Price * (double)InventoryQty;
            }
            else if (drpDownInventory.SelectedIndex == 32)
            {
                InventoryPreTax = A2Price * (double)InventoryQty;
            }
            else if (drpDownInventory.SelectedIndex == 33)
            {
                InventoryPreTax = A2Price * (double)InventoryQty;
            }
            else if (drpDownInventory.SelectedIndex == 34)
            {
                InventoryPreTax = A2Price * (double)InventoryQty;
            }
            else if (drpDownInventory.SelectedIndex == 35)
            {
                InventoryPreTax = A2Price * (double)InventoryQty;
            }
            else if (drpDownInventory.SelectedIndex == 36)
            {
                InventoryPreTax = A2Price * (double)InventoryQty;
            }
            else if (drpDownInventory.SelectedIndex == 37)
            {
                InventoryPreTax = A2Price * (double)InventoryQty;
            }
            else if (drpDownInventory.SelectedIndex == 38)
            {
                InventoryPreTax = A2Price * (double)InventoryQty;
            }
            else if (drpDownInventory.SelectedIndex == 39)
            {
                InventoryPreTax = A2Price * (double)InventoryQty;
            }
            else if (drpDownInventory.SelectedIndex == 40)
            {
                InventoryPreTax = A2Price * (double)InventoryQty;
            }
            else if (drpDownInventory.SelectedIndex == 41)
            {
                InventoryPreTax = A2Price * (double)InventoryQty;
            }
            else if (drpDownInventory.SelectedIndex == 42)
            {
                InventoryPreTax = A2Price * (double)InventoryQty;
            }
            else if (drpDownInventory.SelectedIndex == 43)
            {
                InventoryPreTax = A2Price * (double)InventoryQty;
            }
            else if (drpDownInventory.SelectedIndex == 44)
            {
                InventoryPreTax = A2Price * (double)InventoryQty;
            }
            else if (drpDownInventory.SelectedIndex == 45)
            {
                InventoryPreTax = A2Price * (double)InventoryQty;
            }
            else if (drpDownInventory.SelectedIndex == 46)
            {
                InventoryPreTax = A2Price * (double)InventoryQty;
            }
            else if (drpDownInventory.SelectedIndex == 47)
            {
                InventoryPreTax = A3Price * (double)InventoryQty;
            }
            else if (drpDownInventory.SelectedIndex == 48)
            {
                InventoryPreTax = A3Price * (double)InventoryQty;
            }
            else if (drpDownInventory.SelectedIndex == 49)
            {
                InventoryPreTax = A4Price * (double)InventoryQty;
            }
            else if (drpDownInventory.SelectedIndex == 50)
            {
                InventoryPreTax = A3Price * (double)InventoryQty;
            }
            else if (drpDownInventory.SelectedIndex == 51)
            {
                InventoryPreTax = A2Price * (double)InventoryQty;
            }
            else if (drpDownInventory.SelectedIndex == 52)
            {
                InventoryPreTax = A2Price * (double)InventoryQty;
            }
            else if (drpDownInventory.SelectedIndex == 53)
            {
                InventoryPreTax = A2Price * (double)InventoryQty;
            }
            else if (drpDownInventory.SelectedIndex == 54)
            {
                InventoryPreTax = A2Price * (double)InventoryQty;
            }
            else if (drpDownInventory.SelectedIndex == 55)
            {
                InventoryPreTax = A2Price * (double)InventoryQty;
            }
            else if (drpDownInventory.SelectedIndex == 56)
            {
                InventoryPreTax = A2Price * (double)InventoryQty;
            }
            else if (drpDownInventory.SelectedIndex == 57)
            {
                InventoryPreTax = A2Price * (double)InventoryQty;
            }
            else if (drpDownInventory.SelectedIndex == 58)
            {
                InventoryPreTax = A2Price * (double)InventoryQty;
            }
            else
            {
                InventoryPreTax = 0;
            }

            richTxtBoxInventory.Text = "You have ordered " + txtBoxInvQty.Text.ToString() + " of " + drpDownInventory.SelectedItem.ToString() + " - " + InventoryPreTax.ToString("C");

            InventorySalesTax = InventoryPreTax * 0.001;
            InventoryTotal = InventoryPreTax + InventorySalesTax;

            txtBoxInvPreTax.Text = InventoryPreTax.ToString("C");
            txtBoxInvSalesTax.Text = InventorySalesTax.ToString("C");
            txtBoxInvTotal.Text = InventoryTotal.ToString("C");

        }
        private void bttnOrderInventory_Click(object sender, EventArgs e)
        {
            if (Walton_DB.ExecSqlString("INSERT INTO InventoryOrderingLog (Inventory_Name, Qty_Ordered, Date_Ordered) VALUES ('" + drpDownInventory.SelectedItem.ToString() + "','" + txtBoxInvQty.Text + "','" + txtBoxInvDate.Text + "')"))
            {
                MessageBox.Show("Inventory Order Logged!");
            }


            drpDownInventory.SelectedIndex = -1;
            txtBoxInvQty.Text = "";
            txtBoxInvSalesTax.Text = "";
            txtBoxInvPreTax.Text = "";
            txtBoxInvTotal.Text = "";
            richTxtBoxInventory.Text = "";
            txtBoxInvDate.Text = "";

        }
        private void bttnClearInventory_Click(object sender, EventArgs e)
        {
            drpDownInventory.SelectedIndex = -1;
            txtBoxInvQty.Text = "";
            txtBoxInvSalesTax.Text = "";
            txtBoxInvPreTax.Text = "";
            txtBoxInvTotal.Text = "";
            richTxtBoxInventory.Text = "";
        }

        private void bttnExitInventory_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bttnClearExpenses_Click(object sender, EventArgs e)
        {
            txtBoxExpseDesc.Text = "";
            txtBoxExpseAmt.Text = "";
        }

        private void bttnExitExpenses_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void bttnCompleteOrder_Click(object sender, EventArgs e)
        {

            if (Walton_DB.ExecSqlString("INSERT INTO Payment (Customer, aDue, aPaid) VALUES ('" + txtCustomerName.Text.ToString() + "','" + txtBoxTotal.Text.ToString() + "','" + txtBoxTotal.Text.ToString() + "')"))
            {
                MessageBox.Show("Order Completed!");
                
            }

            txtBoxBowlQty.Text = "";
            txtBoxPreTaxTot.Text = "";
            txtBoxRewardsFromOrder.Text = "";
            txtBoxSalesTaxTotal.Text = "";
            txtBoxShootersQty.Text = "";
            txtBoxSmoothieQty.Text = "";
            txtBoxTotal.Text = "";
            txtCustomerName.Text = "";
            txtRewardsTelephone.Text = "";
            drpDownBowls.SelectedIndex = -1;
            drpDownShooters.SelectedIndex = -1;
            drpDownSmoothies.SelectedIndex = -1;
            drpDownPhoneNum.SelectedIndex = -1;
            richTextBoxOrderSummary.Text = "";
        }

        private void bttnAddExpense_Click(object sender, EventArgs e)
        {

            if (Walton_DB.ExecSqlString("INSERT INTO Expense (eDesc, expseCost) VALUES ('" + txtBoxExpseDesc.Text + "','" + txtBoxExpseAmt.Text + "')"))
            {
                MessageBox.Show("Expense Added!");
            }

            txtBoxExpseAmt.Text = "";
            txtBoxExpseDesc.Text = "";
        }
        

       
    }
}



