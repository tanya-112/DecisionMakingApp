using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DecisionMakingApp
{
    
    public partial class Form1 : Form
    {
        string goalStr;
        string[] optionsArray;
        string[] criteriaArray;
        double[,] criteriaComparison;
        Dictionary<string, double> valuesToSelectFrom;
        List<ComboBox> cBoxListCrit;
        List<ComboBox> cBoxListOpt;
        List<double[,]> compOptByCritArrayList;
        double[,] optWeightsInEachCritArr;
        double[] criteriaWeight;
        double T;

        public Form1()
        {
            InitializeComponent();
        }

        private void next_button_Click(object sender, EventArgs e)
        {
            cBoxListCrit = new List<ComboBox>();
            valuesToSelectFrom = new Dictionary<string, double>();
            valuesToSelectFrom.Add("1 = по важности", 1);
            valuesToSelectFrom.Add("2 едва ли превосходит", 2);
            valuesToSelectFrom.Add("3 умеренно превосходит", 3);
            valuesToSelectFrom.Add("4 превосходит чуть больше, чем умеренно", 4);
            valuesToSelectFrom.Add("5 существенно или сильно превосходит", 5);
            valuesToSelectFrom.Add("6 превосходит чуть больше, чем существенно", 6);
            valuesToSelectFrom.Add("7 значительно превосходит", 7);
            valuesToSelectFrom.Add("8 превосходит чуть больше,чем значительно", 8);
            valuesToSelectFrom.Add("9 очень сильно превосходит", 9);
            valuesToSelectFrom.Add("1/2 едва ли \"превосходится\"", 0.5);// 1/2
            valuesToSelectFrom.Add("1/3 умеренно \"превосходится\"", 0.3333333333);// 1/3
            valuesToSelectFrom.Add("1/4 \"превосходится\" чуть больше, чем умеренно", 0.25);// 1/4
            valuesToSelectFrom.Add("1/5 существенно или сильно \"превосходится\"", 0.2); // 1/5
            valuesToSelectFrom.Add("1/6 \"превосходится\" чуть больше, чем существенно", 0.1666666667);// 1/6
            valuesToSelectFrom.Add("1/7 значительно \"превосходится\"", 0.1428571429); // 1/7
            valuesToSelectFrom.Add("1/8 \"превосходится\" чуть больше,чем значительно", 0.125);// 1/8
            valuesToSelectFrom.Add("1/9 очень сильно \"превосходится\"", 0.1111111111);// 1/9

            goalStr = goal_textBox.Text;
            string criteriaStr = criteria_textBox.Text;
            string[] separ = { ",", "." };
            criteriaArray = criteriaStr.Split(separ, StringSplitOptions.RemoveEmptyEntries);//записали все критерии в массив
            string optionsStr = options_textBox.Text;
            optionsArray = optionsStr.Split(separ, StringSplitOptions.RemoveEmptyEntries);//записали все альтернативы в массив
            panel2.Controls.Clear();
            panel1.Controls.Remove(next_button);
            int k = 1;
            int v;
            int i = 0;
            int j = 0;
            Label lb1 = new Label();
            lb1.Location = new System.Drawing.Point(290, 40);
            lb1.AutoSize = true;
            lb1.Text = "СРАВНИТЕ ВСЕ КРИТЕРИИ ПО ВАЖНОСТИ";
            panel2.Controls.Add(lb1);
            foreach (string criteria in criteriaArray)//p-ая итерация внутри цикла foreach создает интерфейс для сравнения конкретного p-го критерия с остальными
            {
                v = 0;
                for (int iter = 0; iter < criteriaArray.Length - 1; iter++)//i-ая итерация внутри цикла foreach создает интерфейс для сравнения p-го критерия с i-ым
                {
                    Label lbl = new Label();//label, находящийся слева
                    lbl.Location = new System.Drawing.Point(52, 58 + (k * 30));
                    lbl.Name = "label_" + k.ToString();
                    lbl.AutoSize = true;
                    lbl.Text = criteria;
                    panel2.Controls.Add(lbl);
                    Label lbl2 = new Label();//label, находящийся справа
                    lbl2.Location = new System.Drawing.Point(580, 58 + (k * 30));
                    lbl2.Name = "label_" + k.ToString() + "2";
                    lbl2.AutoSize = true;
                    if (Array.IndexOf(criteriaArray, criteria) != (v))
                        lbl2.Text = criteriaArray[v];
                    else
                    {
                        v++;
                        lbl2.Text = criteriaArray[v];
                    }
                    panel2.Controls.Add(lbl2);

                    ComboBox cbox = new ComboBox();
                    cbox.Location = new System.Drawing.Point(265, 58 + (k * 30));
                    cbox.Width = 287;
                    cbox.Name = "comboBox_" + iter.ToString();                 
                    foreach (var x in valuesToSelectFrom.Keys)
                        cbox.Items.Add(x);
                    cBoxListCrit.Add(cbox);
                    panel2.Controls.Add(cbox);

                    k++;
                    v++;
                    j++;
                }
                i++;                
            }
            Button next_button2 = new Button();
            next_button2.Location = new System.Drawing.Point(800, 280);
            next_button2.Text = "Далее";
            next_button2.Name = "next_button2";
            next_button2.Click += new System.EventHandler(next_button2_Click);
            panel2.Controls.Add(next_button2);
        }
        private void next_button2_Click(object sender, EventArgs e)
        {
            cBoxListOpt = new List<ComboBox>();
            SaveCriteriaComparisonData();
            FindCriteriaWeights();
            //ПРОВЕРКА СОГЛАСОВАННОСТИ УКАЗАННЫХ ПОЛЬЗОВАТЕЛЕМ ДАННЫХ
            CheckConsistency();
            if (T > 0.2)
            {
                Label lblRedo = new Label();
                lblRedo.Text = "Проверьте, пожалуйста, корректно \nли Вы сравнили все критерии.\nДанные недостаточно согласованы.";
                lblRedo.Location = new System.Drawing.Point(772, 300);
                lblRedo.AutoSize = true;
                panel2.Controls.Add(lblRedo);
            }
            else
            {
                panel2.Controls.Clear();
                int k = 1;
                int v;
                Label lb1 = new Label();
                lb1.Location = new System.Drawing.Point(225, 40);
                lb1.AutoSize = true;
                lb1.Text = "СРАВНИТЕ АЛЬТЕРНАТИВЫ ПО КАЧЕСТВУ В РАМКАХ КАЖДОГО ИЗ КРИТЕРИЕВ";
                panel2.Controls.Add(lb1);
                foreach (string criteria in criteriaArray)//p-ая итерация внутри цикла foreach создает интерфейс для сравнения альтернатив между собой по p-му критерию
                {
                    k += 2;
                    Label lbl = new Label();
                    lbl.Location = new System.Drawing.Point(290, 58 + (k * 30));
                    lbl.AutoSize = true;
                    lbl.Text = "По критерию: " + criteria;
                    lbl.Width = 200;
                    panel2.Controls.Add(lbl);
                    foreach (string option in optionsArray)
                    {
                        v = 0;
                        for (int i = 0; i < optionsArray.Length - 1; i++)//i-ая итерация внутри цикла foreach создает интерфейс для сравнения p-го критерия с i-ым
                        {
                            k++;
                            Label lbl1 = new Label();//label, находящийся слева
                            lbl1.Location = new System.Drawing.Point(52, 58 + (k * 30));
                            lbl1.Name = "label_" + k.ToString();
                            lbl1.AutoSize = true;
                            lbl1.Text = option;
                            panel2.Controls.Add(lbl1);
                            Label lbl2 = new Label();//label, находящийся справа
                            lbl2.Location = new System.Drawing.Point(580, 58 + (k * 30));
                            lbl2.Name = "label_" + k.ToString() + "2";
                            lbl2.AutoSize = true;
                            if (Array.IndexOf(optionsArray, option) != (v))
                                lbl2.Text = optionsArray[v];
                            else
                            {
                                v++;
                                lbl2.Text = optionsArray[v];
                            }
                            panel2.Controls.Add(lbl2);

                            ComboBox cbox = new ComboBox();
                            cbox.Location = new System.Drawing.Point(293, 58 + (k * 30));
                            cbox.Width = 287;
                            cbox.Name = "comboBox_" + k.ToString();
                            foreach (var x in valuesToSelectFrom.Keys)
                                cbox.Items.Add(x);
                            cBoxListOpt.Add(cbox);
                            panel2.Controls.Add(cbox);
                            v++;
                        }
                    }
                }
                Button next_button3 = new Button();
                next_button3.Location = new System.Drawing.Point(820,321);
                next_button3.Text = "Далее";
                next_button3.Name = "next_button3";
                next_button3.Click += new System.EventHandler(next_button3_Click);
                panel2.Controls.Add(next_button3);
            }
        }

        private void next_button3_Click(object sender, EventArgs e)
        {
            SaveOptionsComparisonData();
            panel2.Controls.Clear();
            FindBestOption();
        }

        private void SaveCriteriaComparisonData()
        {
            criteriaComparison = new double[criteriaArray.Length, criteriaArray.Length];
            int v = 0;
            for (int i = 0; i < criteriaArray.Length; i++)
                for (int j = 0; j < criteriaArray.Length; j++)
                {
                    if (i != j)
                    {
                        criteriaComparison[i, j] = valuesToSelectFrom[cBoxListCrit[v].SelectedItem + ""];
                        v++;
                    }
                    else criteriaComparison[i, j] = 1;//заполняем диагональ единицами
                }
        }

        private void SaveOptionsComparisonData()
        {
            compOptByCritArrayList = new List<double[,]>();
            int v = 0;
            for (int k = 0; k < criteriaArray.Length; k++) 
            {
                double[,] compByCrit_i = new double[optionsArray.Length, optionsArray.Length];
                for (int i = 0; i < optionsArray.Length; i++)
                    for (int j = 0; j < optionsArray.Length; j++) 
                    {
                        if (i != j)
                        {
                            compByCrit_i[i, j] = valuesToSelectFrom[cBoxListOpt[v].SelectedItem + ""];
                            v++;
                        }
                        else compByCrit_i[i, j] = 1;
                    }
                compOptByCritArrayList.Add(compByCrit_i);
            }

    }

        private void FindCriteriaWeights()
        {
            //находим веса всех критериев
            double[] eigenVectorCrit = new double[criteriaArray.Length];
            criteriaWeight = new double[criteriaArray.Length];
            double sum = 0;
            for (int i = 0; i < criteriaArray.Length; i++)
            {
                eigenVectorCrit[i] = 1;
                for (int j = 0; j < criteriaArray.Length; j++)
                {
                    eigenVectorCrit[i] *= criteriaComparison[i, j];
                }
                eigenVectorCrit[i] = Math.Pow(eigenVectorCrit[i], 1.0 / (criteriaArray.Length));//посчитали собственный вектор для i-го критерия
                sum += eigenVectorCrit[i];
            }

            for (int i = 0; i < criteriaArray.Length; i++)
                    criteriaWeight[i] = eigenVectorCrit[i] / sum;//посчитали вес каждого критерия
        }
         private void CheckConsistency()
        {
            Dictionary<int, double> helpTable = new Dictionary<int, double>();
            helpTable.Add(1, 0);
            helpTable.Add(2, 0);
            helpTable.Add(3, 0.58);
            helpTable.Add(4, 0.9);
            helpTable.Add(5, 1.12);
            helpTable.Add(6, 1.24);
            helpTable.Add(7, 1.32);
            helpTable.Add(8, 1.41);
            helpTable.Add(9, 1.45);
            helpTable.Add(10, 1.49);
            double[] lambda = new double[criteriaArray.Length];
            double lambdaMax = 0;
            for (int j = 0; j < criteriaArray.Length; j++)
            {
                lambda[j] = 0;
                for (int i = 0; i < criteriaArray.Length; i++)
                {
                    lambda[j] += criteriaComparison[i,j];
                }
                lambda[j] *= criteriaWeight[j];
                lambdaMax += lambda[j];
            }
            double indexOfConsistency = (lambdaMax - criteriaArray.Length) / (criteriaArray.Length - 1);
            double R = helpTable[criteriaArray.Length];
            T = indexOfConsistency / R;          
        }
 private void FindOptionsWeights()
        {
            //находим веса всех альтернатив в разрезе каждого из критериев
            double[] eigenVectorOpt = new double[optionsArray.Length];//массив собственных векторов всех альтернатив в разрезе одного из критериев (критерий меняется в последующем цикле)
            double[] optionWeight = new double[optionsArray.Length];
            optWeightsInEachCritArr = new double[criteriaArray.Length,optionsArray.Length];//1я строка будет хранить веса всех альтернатив в разрезе 1го критерия, 2я строка-в разрезе 2го критерия и т.д. 
            int arrNumber = 0;
            foreach (double[,] arr in compOptByCritArrayList)
            {
                double sum2 = 0;
                for (int i = 0; i < optionsArray.Length; i++)
                {
                    eigenVectorOpt[i] = 1;
                    for (int j = 0; j < optionsArray.Length; j++)
                    {
                        eigenVectorOpt[i] *= arr[i, j];
                    }
                    eigenVectorOpt[i] = Math.Pow(eigenVectorOpt[i], 1.0 / (optionsArray.Length));
                    sum2 += eigenVectorOpt[i];
                }

                for (int i = 0; i < optionsArray.Length; i++)
                {
                    optionWeight[i] = eigenVectorOpt[i] / sum2;//посчитали вес каждой альтернативы в разрезе критерия arr
                    optWeightsInEachCritArr[arrNumber, i] = optionWeight[i];
                }
                arrNumber++;
            }
        }
        private void FindBestOption()
        {
            FindOptionsWeights();
            //определяем интегральные значения показателей качества каждой из альтернатив
            double[] integralValue = new double[optionsArray.Length];
            for (int i = 0; i < optionsArray.Length; i++)
            {
                integralValue[i] = 0;
                for (int j = 0; j < criteriaArray.Length; j++)
                {
                    integralValue[i] += criteriaWeight[j] * optWeightsInEachCritArr[j,i];
                }
            }

            //определяем альтернативу с наибольшим интегральным показателем качества
            double max = 0;
            string bestOption = "not found";
            for (int i = 0; i < optionsArray.Length; i++) 
            {
                if (integralValue[i] > max)
                {
                    max = integralValue[i];
                    bestOption = optionsArray[i];
                }
            }

            //выводим пользователю на экран результаты
            Label lb1 = new Label();
            lb1.Location = new System.Drawing.Point(52, 10);
            lb1.AutoSize = true;
            lb1.Text = "Цель: " + goalStr;
            panel2.Controls.Add(lb1);
            for (int i = 0; i < optionsArray.Length; i++)
            {
                Label lblOpt = new Label();
                lblOpt.Text = "Вариант: "+optionsArray[i];
                lblOpt.Location = new System.Drawing.Point(52, 58 + (i * 30));
                lblOpt.AutoSize = true;
                Label lblValue = new Label();
                lblValue.Text = "Показатель качества: "+integralValue[i].ToString();
                lblValue.Location = new System.Drawing.Point(370, 58 + (i * 30));
                lblValue.AutoSize = true;
                panel2.Controls.Add(lblOpt);
                panel2.Controls.Add(lblValue);
            }

            Label lblBestOpt = new Label();
            lblBestOpt.Text = "НАИЛУЧШИЙ ВАРИАНТ: "+ bestOption;
            lblBestOpt.Location = new System.Drawing.Point(550, 200);
            lblBestOpt.AutoSize = true;
            panel2.Controls.Add(lblBestOpt);
        }

    }
}
