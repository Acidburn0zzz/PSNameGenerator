namespace PSNameGenerator
{
    partial class GUIProgram
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
            this.tableLayoutPanelForm = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelConfig = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxType = new System.Windows.Forms.GroupBox();
            this.radioButtonTypeMale = new System.Windows.Forms.RadioButton();
            this.radioButtonTypeFemale = new System.Windows.Forms.RadioButton();
            this.radioButtonTypeFamily = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanelParameter = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxParameters = new System.Windows.Forms.GroupBox();
            this.buttonGenerate = new System.Windows.Forms.Button();
            this.textBoxOutput = new System.Windows.Forms.TextBox();
            this.tableLayoutPanelParamInner = new System.Windows.Forms.TableLayoutPanel();
            this.labelMax = new System.Windows.Forms.Label();
            this.labelMin = new System.Windows.Forms.Label();
            this.labelCount = new System.Windows.Forms.Label();
            this.labelLength = new System.Windows.Forms.Label();
            this.numericUpDownCountMax = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownLengthMax = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownLengthMin = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanelForm.SuspendLayout();
            this.tableLayoutPanelConfig.SuspendLayout();
            this.groupBoxType.SuspendLayout();
            this.tableLayoutPanelParameter.SuspendLayout();
            this.groupBoxParameters.SuspendLayout();
            this.tableLayoutPanelParamInner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCountMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLengthMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLengthMin)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanelForm
            // 
            this.tableLayoutPanelForm.ColumnCount = 1;
            this.tableLayoutPanelForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelForm.Controls.Add(this.tableLayoutPanelConfig, 0, 0);
            this.tableLayoutPanelForm.Controls.Add(this.textBoxOutput, 0, 1);
            this.tableLayoutPanelForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelForm.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelForm.Name = "tableLayoutPanelForm";
            this.tableLayoutPanelForm.RowCount = 2;
            this.tableLayoutPanelForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanelForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelForm.Size = new System.Drawing.Size(372, 355);
            this.tableLayoutPanelForm.TabIndex = 0;
            // 
            // tableLayoutPanelConfig
            // 
            this.tableLayoutPanelConfig.ColumnCount = 2;
            this.tableLayoutPanelConfig.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelConfig.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelConfig.Controls.Add(this.groupBoxType, 0, 0);
            this.tableLayoutPanelConfig.Controls.Add(this.tableLayoutPanelParameter, 1, 0);
            this.tableLayoutPanelConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelConfig.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelConfig.Name = "tableLayoutPanelConfig";
            this.tableLayoutPanelConfig.RowCount = 1;
            this.tableLayoutPanelConfig.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelConfig.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelConfig.Size = new System.Drawing.Size(366, 144);
            this.tableLayoutPanelConfig.TabIndex = 0;
            // 
            // groupBoxType
            // 
            this.groupBoxType.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxType.Controls.Add(this.radioButtonTypeFamily);
            this.groupBoxType.Controls.Add(this.radioButtonTypeFemale);
            this.groupBoxType.Controls.Add(this.radioButtonTypeMale);
            this.groupBoxType.Location = new System.Drawing.Point(3, 3);
            this.groupBoxType.Name = "groupBoxType";
            this.groupBoxType.Size = new System.Drawing.Size(177, 138);
            this.groupBoxType.TabIndex = 0;
            this.groupBoxType.TabStop = false;
            this.groupBoxType.Text = "Generation Type";
            // 
            // radioButtonTypeMale
            // 
            this.radioButtonTypeMale.AutoSize = true;
            this.radioButtonTypeMale.Checked = true;
            this.radioButtonTypeMale.Location = new System.Drawing.Point(7, 20);
            this.radioButtonTypeMale.Name = "radioButtonTypeMale";
            this.radioButtonTypeMale.Size = new System.Drawing.Size(79, 17);
            this.radioButtonTypeMale.TabIndex = 0;
            this.radioButtonTypeMale.TabStop = true;
            this.radioButtonTypeMale.Text = "Male Name";
            this.radioButtonTypeMale.UseVisualStyleBackColor = true;
            // 
            // radioButtonTypeFemale
            // 
            this.radioButtonTypeFemale.AutoSize = true;
            this.radioButtonTypeFemale.Location = new System.Drawing.Point(7, 44);
            this.radioButtonTypeFemale.Name = "radioButtonTypeFemale";
            this.radioButtonTypeFemale.Size = new System.Drawing.Size(90, 17);
            this.radioButtonTypeFemale.TabIndex = 1;
            this.radioButtonTypeFemale.TabStop = true;
            this.radioButtonTypeFemale.Text = "Female Name";
            this.radioButtonTypeFemale.UseVisualStyleBackColor = true;
            // 
            // radioButtonTypeFamily
            // 
            this.radioButtonTypeFamily.AutoSize = true;
            this.radioButtonTypeFamily.Location = new System.Drawing.Point(7, 68);
            this.radioButtonTypeFamily.Name = "radioButtonTypeFamily";
            this.radioButtonTypeFamily.Size = new System.Drawing.Size(85, 17);
            this.radioButtonTypeFamily.TabIndex = 2;
            this.radioButtonTypeFamily.TabStop = true;
            this.radioButtonTypeFamily.Text = "Family Name";
            this.radioButtonTypeFamily.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelParameter
            // 
            this.tableLayoutPanelParameter.ColumnCount = 1;
            this.tableLayoutPanelParameter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelParameter.Controls.Add(this.groupBoxParameters, 0, 0);
            this.tableLayoutPanelParameter.Controls.Add(this.buttonGenerate, 0, 1);
            this.tableLayoutPanelParameter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelParameter.Location = new System.Drawing.Point(186, 3);
            this.tableLayoutPanelParameter.Name = "tableLayoutPanelParameter";
            this.tableLayoutPanelParameter.RowCount = 2;
            this.tableLayoutPanelParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelParameter.Size = new System.Drawing.Size(177, 138);
            this.tableLayoutPanelParameter.TabIndex = 1;
            // 
            // groupBoxParameters
            // 
            this.groupBoxParameters.Controls.Add(this.tableLayoutPanelParamInner);
            this.groupBoxParameters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxParameters.Location = new System.Drawing.Point(3, 3);
            this.groupBoxParameters.Name = "groupBoxParameters";
            this.groupBoxParameters.Size = new System.Drawing.Size(171, 102);
            this.groupBoxParameters.TabIndex = 0;
            this.groupBoxParameters.TabStop = false;
            this.groupBoxParameters.Text = "Generation Parameters";
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGenerate.Location = new System.Drawing.Point(99, 111);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(75, 24);
            this.buttonGenerate.TabIndex = 1;
            this.buttonGenerate.Text = "Generate";
            this.buttonGenerate.UseVisualStyleBackColor = true;
            this.buttonGenerate.Click += new System.EventHandler(this.buttonGenerate_Click);
            // 
            // textBoxOutput
            // 
            this.textBoxOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxOutput.Location = new System.Drawing.Point(3, 153);
            this.textBoxOutput.Multiline = true;
            this.textBoxOutput.Name = "textBoxOutput";
            this.textBoxOutput.Size = new System.Drawing.Size(366, 199);
            this.textBoxOutput.TabIndex = 1;
            // 
            // tableLayoutPanelParamInner
            // 
            this.tableLayoutPanelParamInner.ColumnCount = 3;
            this.tableLayoutPanelParamInner.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanelParamInner.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelParamInner.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelParamInner.Controls.Add(this.labelMax, 1, 0);
            this.tableLayoutPanelParamInner.Controls.Add(this.labelMin, 2, 0);
            this.tableLayoutPanelParamInner.Controls.Add(this.labelCount, 0, 1);
            this.tableLayoutPanelParamInner.Controls.Add(this.labelLength, 0, 2);
            this.tableLayoutPanelParamInner.Controls.Add(this.numericUpDownCountMax, 1, 1);
            this.tableLayoutPanelParamInner.Controls.Add(this.numericUpDownLengthMax, 1, 2);
            this.tableLayoutPanelParamInner.Controls.Add(this.numericUpDownLengthMin, 2, 2);
            this.tableLayoutPanelParamInner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelParamInner.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanelParamInner.Name = "tableLayoutPanelParamInner";
            this.tableLayoutPanelParamInner.RowCount = 3;
            this.tableLayoutPanelParamInner.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tableLayoutPanelParamInner.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelParamInner.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelParamInner.Size = new System.Drawing.Size(165, 83);
            this.tableLayoutPanelParamInner.TabIndex = 0;
            // 
            // labelMax
            // 
            this.labelMax.AutoSize = true;
            this.labelMax.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelMax.Location = new System.Drawing.Point(53, 0);
            this.labelMax.Name = "labelMax";
            this.labelMax.Size = new System.Drawing.Size(51, 18);
            this.labelMax.TabIndex = 0;
            this.labelMax.Text = "Max";
            // 
            // labelMin
            // 
            this.labelMin.AutoSize = true;
            this.labelMin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelMin.Location = new System.Drawing.Point(110, 0);
            this.labelMin.Name = "labelMin";
            this.labelMin.Size = new System.Drawing.Size(52, 18);
            this.labelMin.TabIndex = 1;
            this.labelMin.Text = "Min";
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelCount.Location = new System.Drawing.Point(3, 18);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(44, 32);
            this.labelCount.TabIndex = 2;
            this.labelCount.Text = "Count";
            this.labelCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelLength
            // 
            this.labelLength.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelLength.AutoSize = true;
            this.labelLength.Location = new System.Drawing.Point(3, 50);
            this.labelLength.Name = "labelLength";
            this.labelLength.Size = new System.Drawing.Size(44, 33);
            this.labelLength.TabIndex = 3;
            this.labelLength.Text = "Length";
            this.labelLength.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numericUpDownCountMax
            // 
            this.numericUpDownCountMax.Location = new System.Drawing.Point(53, 21);
            this.numericUpDownCountMax.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numericUpDownCountMax.Name = "numericUpDownCountMax";
            this.numericUpDownCountMax.Size = new System.Drawing.Size(51, 20);
            this.numericUpDownCountMax.TabIndex = 4;
            // 
            // numericUpDownLengthMax
            // 
            this.numericUpDownLengthMax.Location = new System.Drawing.Point(53, 53);
            this.numericUpDownLengthMax.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numericUpDownLengthMax.Name = "numericUpDownLengthMax";
            this.numericUpDownLengthMax.Size = new System.Drawing.Size(51, 20);
            this.numericUpDownLengthMax.TabIndex = 5;
            // 
            // numericUpDownLengthMin
            // 
            this.numericUpDownLengthMin.Location = new System.Drawing.Point(110, 53);
            this.numericUpDownLengthMin.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numericUpDownLengthMin.Name = "numericUpDownLengthMin";
            this.numericUpDownLengthMin.Size = new System.Drawing.Size(52, 20);
            this.numericUpDownLengthMin.TabIndex = 6;
            // 
            // GUIProgram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 355);
            this.Controls.Add(this.tableLayoutPanelForm);
            this.Name = "GUIProgram";
            this.Text = "PS Name Generator";
            this.tableLayoutPanelForm.ResumeLayout(false);
            this.tableLayoutPanelForm.PerformLayout();
            this.tableLayoutPanelConfig.ResumeLayout(false);
            this.groupBoxType.ResumeLayout(false);
            this.groupBoxType.PerformLayout();
            this.tableLayoutPanelParameter.ResumeLayout(false);
            this.groupBoxParameters.ResumeLayout(false);
            this.tableLayoutPanelParamInner.ResumeLayout(false);
            this.tableLayoutPanelParamInner.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCountMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLengthMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLengthMin)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelForm;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelConfig;
        private System.Windows.Forms.GroupBox groupBoxType;
        private System.Windows.Forms.RadioButton radioButtonTypeFamily;
        private System.Windows.Forms.RadioButton radioButtonTypeFemale;
        private System.Windows.Forms.RadioButton radioButtonTypeMale;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelParameter;
        private System.Windows.Forms.GroupBox groupBoxParameters;
        private System.Windows.Forms.Button buttonGenerate;
        private System.Windows.Forms.TextBox textBoxOutput;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelParamInner;
        private System.Windows.Forms.Label labelMax;
        private System.Windows.Forms.Label labelMin;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.Label labelLength;
        private System.Windows.Forms.NumericUpDown numericUpDownCountMax;
        private System.Windows.Forms.NumericUpDown numericUpDownLengthMax;
        private System.Windows.Forms.NumericUpDown numericUpDownLengthMin;
    }
}