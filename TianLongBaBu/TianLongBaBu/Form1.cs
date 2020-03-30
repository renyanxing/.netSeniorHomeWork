using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TianLongBaBu.Model;

namespace TianLongBaBu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private bool StoryBegining = false;
        private void Begining_Click(object sender, EventArgs e)
        {
            Begining.Enabled = false;
            CancellationTokenSource cancel = new CancellationTokenSource();
            CancellationTokenSource cancelVoiceover = new CancellationTokenSource();

            ActorBase qiaoFeng = new QiaoFeng();
            ActorBase duanYu = new DuanYu();
            ActorBase xuZhu = new XuZhu();
            List<Task> taskList = new List<Task>();
            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {

                    if (item.Name.Contains("QiaoFeng"))
                    {
                        TextBox textBox = (TextBox)item;
                        taskList.Add(Task.Run(() => ActorDoing(qiaoFeng, textBox, cancel), cancel.Token));
                    }
                    if (item.Name.Contains("DuanYu"))
                    {
                        TextBox textBox = (TextBox)item;
                        taskList.Add(Task.Run(() => ActorDoing(duanYu, textBox, cancel), cancel.Token));
                    }
                    if (item.Name.Contains("XuZhu"))
                    {
                        TextBox textBox = (TextBox)item;
                        taskList.Add(Task.Run(() => ActorDoing(xuZhu, textBox, cancel), cancel.Token));
                    }
                }

            }
            Task.Run(() =>
            {
                Task task = new Task(() =>
                {
                    //Thread.Sleep(7000);
                    //this.Invoke(new Action(() =>
                    //{
                    //    UpdateView(VoiceoverShow, "天降雷霆灭世，天龙八部的故事就此结束....", cancelVoiceover, cancel);
                    //    this.Begining.Enabled = true;
                    //}));

                    //return;
                    while (!cancelVoiceover.IsCancellationRequested)
                    {
                        Thread.Sleep(200);
                        if (new Random().Next(2000, 2050) == DateTime.Now.Year)
                        {
                            this.Invoke(new Action(() =>
                            {
                                UpdateView(VoiceoverShow, "天降雷霆灭世，天龙八部的故事就此结束....", cancelVoiceover, cancel);
                                this.Begining.Enabled = true;
                            }));
                            return;
                        }
                    }
                });
                task.Start();
                task.Wait();
            });
            Task.Run(() =>
            {
                Task.WaitAll(taskList.ToArray());
                if (!cancel.IsCancellationRequested)
                {
                    this.Invoke(new Action(() =>
                    {
                        UpdateView(VoiceoverShow, "中原群雄大战辽兵，忠义两难一死谢天。。。。", cancel, cancelVoiceover);
                        this.Begining.Enabled = true;
                    }));

                }

            }, cancel.Token);



        }

        private object StoryBeginingActionLock = new object();
        private object UpdateViewLock = new object();
        private void StoryBeginingAction(CancellationTokenSource cancel, CancellationTokenSource cancelSignal)
        {

            lock (StoryBeginingActionLock)
            {
  

                UpdateView(VoiceoverShow, "天龙八部就此拉开序幕。。。。", cancel, cancelSignal);
                StoryBegining = !StoryBegining;
            }
        }
        private void VoiceoverShowAction(string action)
        {
            this.VoiceoverShow.Text += $"{action}\r\n";


        }
        private void UpdateView(TextBox textBox, string printTex, CancellationTokenSource cancel, CancellationTokenSource cancelSignal)
        {
            lock (UpdateViewLock)
            {
                if (cancelSignal != null)
                {
                    cancelSignal.Cancel();
                }
                if (cancel.IsCancellationRequested)
                {
                    return;
                }
                textBox.Text += $"{printTex}\r\n\r\n";
            }
        }
        private void ActorDoing(ActorBase actor, TextBox textBox, CancellationTokenSource cancel)
        {

            while (!cancel.IsCancellationRequested)
            {
                if (!actor.Doing(out string action))
                {
                    if (!StoryBegining)
                    {
                        this.Invoke(new Action(() =>
                        {
                            UpdateView(textBox, $"{action}", cancel, null);
                            StoryBeginingAction(cancel, null);
                        }));
                    }
                    else
                    {
                        this.Invoke(new Action(() =>
                        {
                            UpdateView(textBox, $"{action}", cancel, null);
                        }));
                    }
                }
                else
                {
                    this.Invoke(new Action(() =>
                    {
                        UpdateView(textBox, $"{action}", cancel, null);
                        UpdateView(textBox, $"{actor.Name}已经做好准备啦。。。。", cancel, null);
                    }));
                    return;
                }
            }
        }
    }
}
