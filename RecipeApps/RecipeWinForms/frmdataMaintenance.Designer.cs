namespace RecipeWinForms
{
    partial class frmDataMaintenance
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tblMain = new TableLayoutPanel();
            flpDataTypes = new FlowLayoutPanel();
            optStaff = new RadioButton();
            optCuisines = new RadioButton();
            optIngredients = new RadioButton();
            optMeasurements = new RadioButton();
            optCourses = new RadioButton();
            gData = new DataGridView();
            btnSave = new Button();
            tblMain.SuspendLayout();
            flpDataTypes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gData).BeginInit();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 2;
            tblMain.ColumnStyles.Add(new ColumnStyle());
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblMain.Controls.Add(flpDataTypes, 0, 0);
            tblMain.Controls.Add(gData, 1, 0);
            tblMain.Controls.Add(btnSave, 1, 1);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Location = new Point(0, 0);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 2;
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.Size = new Size(939, 574);
            tblMain.TabIndex = 0;
            // 
            // flpDataTypes
            // 
            flpDataTypes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flpDataTypes.Controls.Add(optStaff);
            flpDataTypes.Controls.Add(optCuisines);
            flpDataTypes.Controls.Add(optIngredients);
            flpDataTypes.Controls.Add(optMeasurements);
            flpDataTypes.Controls.Add(optCourses);
            flpDataTypes.Location = new Point(10, 10);
            flpDataTypes.Margin = new Padding(10);
            flpDataTypes.Name = "flpDataTypes";
            tblMain.SetRowSpan(flpDataTypes, 2);
            flpDataTypes.Size = new Size(168, 554);
            flpDataTypes.TabIndex = 0;
            // 
            // optStaff
            // 
            optStaff.Anchor = AnchorStyles.Top;
            optStaff.AutoSize = true;
            optStaff.Checked = true;
            optStaff.Location = new Point(10, 10);
            optStaff.Margin = new Padding(10);
            optStaff.Name = "optStaff";
            optStaff.Size = new Size(59, 25);
            optStaff.TabIndex = 0;
            optStaff.TabStop = true;
            optStaff.Text = "Staff";
            optStaff.UseVisualStyleBackColor = true;
            // 
            // optCuisines
            // 
            optCuisines.Anchor = AnchorStyles.Top;
            optCuisines.AutoSize = true;
            optCuisines.Location = new Point(10, 55);
            optCuisines.Margin = new Padding(10);
            optCuisines.Name = "optCuisines";
            optCuisines.Size = new Size(86, 25);
            optCuisines.TabIndex = 1;
            optCuisines.Text = "Cuisines";
            optCuisines.UseVisualStyleBackColor = true;
            // 
            // optIngredients
            // 
            optIngredients.Anchor = AnchorStyles.Top;
            optIngredients.AutoSize = true;
            optIngredients.Location = new Point(10, 100);
            optIngredients.Margin = new Padding(10);
            optIngredients.Name = "optIngredients";
            optIngredients.Size = new Size(106, 25);
            optIngredients.TabIndex = 2;
            optIngredients.Text = "Ingredients";
            optIngredients.UseVisualStyleBackColor = true;
            // 
            // optMeasurements
            // 
            optMeasurements.Anchor = AnchorStyles.Top;
            optMeasurements.AutoSize = true;
            optMeasurements.Location = new Point(10, 145);
            optMeasurements.Margin = new Padding(10);
            optMeasurements.Name = "optMeasurements";
            optMeasurements.Size = new Size(131, 25);
            optMeasurements.TabIndex = 3;
            optMeasurements.Text = "Measurements";
            optMeasurements.UseVisualStyleBackColor = true;
            // 
            // optCourses
            // 
            optCourses.Anchor = AnchorStyles.Top;
            optCourses.AutoSize = true;
            optCourses.Location = new Point(10, 190);
            optCourses.Margin = new Padding(10);
            optCourses.Name = "optCourses";
            optCourses.Size = new Size(84, 25);
            optCourses.TabIndex = 4;
            optCourses.Text = "Courses";
            optCourses.UseVisualStyleBackColor = true;
            // 
            // gData
            // 
            gData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gData.Dock = DockStyle.Fill;
            gData.Location = new Point(191, 3);
            gData.Name = "gData";
            gData.RowTemplate.Height = 25;
            gData.Size = new Size(745, 506);
            gData.TabIndex = 1;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSave.Location = new Point(802, 522);
            btnSave.Margin = new Padding(10);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(127, 42);
            btnSave.TabIndex = 2;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // frmDataMaintenance
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(939, 574);
            Controls.Add(tblMain);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4);
            Name = "frmDataMaintenance";
            Text = "Hearty Hearth - Data Maintenance";
            tblMain.ResumeLayout(false);
            flpDataTypes.ResumeLayout(false);
            flpDataTypes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gData).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblMain;
        private FlowLayoutPanel flpDataTypes;
        private RadioButton optStaff;
        private RadioButton optCuisines;
        private RadioButton optIngredients;
        private RadioButton optMeasurements;
        private RadioButton optCourses;
        private DataGridView gData;
        private Button btnSave;
    }
}