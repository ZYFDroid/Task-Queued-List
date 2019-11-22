using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyGDIFramework;


namespace TQL
{
    public partial class Form1 : Form
    {
        GdiSystem GDI;
        public Form1()
        {
            InitializeComponent();
            InitializeGdi();
        }

        #region InitializeGDI

        Color backgroundColor = Color.FromArgb(96, 0, 0, 0);
        Pen stdLine = new Pen(new SolidBrush(Color.White), 1f);
        Brush bgPaint = new SolidBrush(Color.FromArgb(96, 0, 0, 0));
        Brush fgPaint = Brushes.White;
        Image foldImg = Properties.Resources.fold;
        float foldRotationAngel = 0;
        Image refreshImg = Properties.Resources.refresh;
        float refreshRotationAngel = 0;
        Image addImg = Properties.Resources.add;
        float addRotateAngel = 0;
        Image reorderImage = Properties.Resources.reorder;

        Image chk_yes = Properties.Resources.chk_yes;
        Image chk_no = Properties.Resources.chk_no;
        Image chk_yes_small = Properties.Resources.chk_yes_small;
        Image chk_no_small = Properties.Resources.chk_no_small;

        Image btnTop = Properties.Resources.top;
        Image btnUp = Properties.Resources.up;
        Image btnDown = Properties.Resources.down;
        Image btnBottom = Properties.Resources.bottom;

        //Font titleBold = new System.Drawing.Font(FontFamily.GenericSerif, 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

        StringFormat alignLeft = new StringFormat(StringFormatFlags.NoWrap);


        void InitializeGdi() {
            alignLeft.LineAlignment = StringAlignment.Center;
            alignLeft.Alignment = StringAlignment.Near;
        }

        #endregion

        Properties.Settings settings = Properties.Settings.Default;

        private void Form1_Load(object sender, EventArgs e)
        {
            GDI = new GdiSystem(this);
            GDI.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            GDI.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            GDI.Graphics.Clear(backgroundColor);
            GDI.UpdateWindow();
            this.Height = panelToolbar.Bottom;

            tblTaskContainer.MouseWheel += TblTaskContainer_MouseWheel;
            this.ActiveControl = tblTaskContainer;
            
            loadConf();
            refreshCountingState();

            try
            {
                this.Location = settings.windowPosition;
            }
            catch {
                settings.Reset();
                settings.Save();
            }

            this.Location = settings.windowPosition;
            if (!settings.isExpanded) {
                btnFold.PerformClick();
            }
            bgPaint = new SolidBrush(Color.FromArgb(settings.backgroundOptacy, Color.Black));
            backgroundColor = Color.FromArgb(settings.backgroundOptacy, Color.Black);

        }

        void saveConf() {
            List<String> saveLines = new List<string>();
            foreach (TickItem ti in tickItems)
            {
                saveLines.Add((ti.ticked ? "T" : "F") + ti.name);
            }
            File.WriteAllLines("task.dat", saveLines);
        }

        void loadConf() {
            if (!File.Exists("task.dat")) {
                tickItems.Add(new TickItem() { name = "阅读使用须知" });
                tickItems.Add(new TickItem() { name = "可以通过标题栏拖动界面" });
                tickItems.Add(new TickItem() { name = "下次启动时界面会在上次退出位置" });
                tickItems.Add(new TickItem() { name = "若界面拖不回来，再次双击程序" });
                tickItems.Add(new TickItem() { name = "单击 加号 可以添加任务" });
                tickItems.Add(new TickItem() { name = "单击 刷新 可移除已完成任务" });
                tickItems.Add(new TickItem() { name = "已完成任务会保存在程序目录下" });
                tickItems.Add(new TickItem() { name = "单击 展开/折叠 按钮展开折叠界面" });
                tickItems.Add(new TickItem() { name = "单击复选框切换任务状态" });
                tickItems.Add(new TickItem() { name = "可以通过排序按钮调整任务顺序" });
                tickItems.Add(new TickItem() { name = "右键标题栏可以退出" });

                return;
            }
            tickItems.Clear();
            string[] lines = File.ReadAllLines("task.dat");
            foreach (string line in lines)
            {
                if (line.Length > 1) {
                    tickItems.Add(new TickItem() { name = line.Substring(1), ticked = line.StartsWith("T") });
                }
            }
        }

        void refreshCountingState() {
            lblTitle.Text = $"事件列表({tickItems.Count(t => t.ticked)}/{tickItems.Count})";

            if (tickItems.All(t => t.ticked))
            {
                lblFirst.Text = "已全部完成";
                btnCompleteFirst.Visible = false;
            }
            else {
                lblFirst.Text = "首要事件："+tickItems.First(t => t.ticked == false).name;
                btnCompleteFirst.Visible = true;
            }

            saveConf();
        }

        private void TblTaskContainer_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                velotery = -0.2f;
            }
            else if(e.Delta < 0) {
                velotery = 0.2f;
            }

            
        }

        List<IAnimate> animations = new List<IAnimate>();

        private void renderTimer_Tick(object sender, EventArgs e)
        {
            for(int repeat=0;repeat<5;repeat++)
            {
                GDI.Graphics.Clear(backgroundColor);
                Graphics g = GDI.Graphics;
                DrawItem(g);
                g.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
                g.FillRectangle(bgPaint, 0, 0, Width, tblTaskContainer.Top);
                g.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceOver;
                g.FillRectangle(bgPaint, 0, dragger.Bottom + 1, Width, tabPageBar.Height);
                g.DrawString(lblTitle.Text, lblTitle.Font, fgPaint, new RectangleF(lblTitle.Location, lblTitle.Size), alignLeft);
                DrawUtils.drawRotateImg(g, foldImg, foldRotationAngel, btnFold.Left + btnFold.Height / 2, btnFold.Top + btnFold.Height / 2, btnFold.Width, btnFold.Height);
                DrawUtils.drawRotateImg(g, refreshImg, refreshRotationAngel, btnRefresh.Left + btnRefresh.Height / 2, btnRefresh.Top + btnRefresh.Height / 2, btnRefresh.Width, btnRefresh.Height);
                DrawUtils.drawRotateImg(g, addImg, addRotateAngel, btnAdd.Left + btnAdd.Height / 2, btnAdd.Top + btnAdd.Height / 2, btnAdd.Width, btnAdd.Height);
                DrawUtils.drawRotateImg(g, reorderImage, 0, btnReorder.Left + btnReorder.Height / 2, btnReorder.Top + btnReorder.Height / 2, btnReorder.Width, btnReorder.Height);

                g.DrawString(lblFirst.Text, lblFirst.Font, fgPaint, new RectangleF(new Point(lblFirst.Left + tabPageBar.Left + 6, lblFirst.Top + tabPageBar.Top), lblFirst.Size), alignLeft);

                if (btnCompleteFirst.Visible)
                {
                    g.DrawImage(btnCompleteFirst.Enabled ? chk_no_small : chk_yes_small, new RectangleF(new Point(btnCompleteFirst.Left + tabPageBar.Left, btnCompleteFirst.Top + tabPageBar.Top), btnCompleteFirst.Size));
                }

                lock (animations)
                {
                    animations.ForEach(an => an.processAnimaFrame());
                    animations.RemoveAll(an => an.finished);
                }

                if (postExpand)
                {
                    postExpand = false;
                    if (!expand)
                    {
                        btnFold.PerformClick();
                    }
                }

                GDI.UpdateWindow();

            }
        }


        bool postExpand = false;

        float velotery = 0;
        /// <summary>
        /// 1 stands for an item.
        /// </summary>
        float position = 0;
        float maxPosition = 1;

        List<TickItem> tickItems = new List<TickItem>();

        Pen splitItem = new Pen(Color.FromArgb(64, 255, 255, 255), 1);

        Brush scrollbarBack = new SolidBrush(Color.FromArgb(48,255,255,255));
        Brush scrollbarBar = new SolidBrush(Color.FromArgb(96,255, 255, 255));

        int postDrag = 0;

        int postSwipe = 0;

        int postClickX = 0;
        int postClickY = 0;

        public void DrawItem(Graphics g) {
            velotery *= 0.95f;
            position += velotery;
            float itemHeight = itemTemplate.Height;
            float panelHeight = tblTaskContainer.Height;
            float panelItems = panelHeight / itemHeight;
            maxPosition = Math.Max(0, (float)tickItems.Count - panelItems);

            if (panelItems >= tickItems.Count)
            {
                position = 0;
                velotery = 0;
            }
            else {
                if (position  > maxPosition) {
                    position = maxPosition;
                    velotery = 0;
                }
                if (position < 0) {
                    position = 0;
                    velotery = 0;
                }

                float scrollBarX = Width - scrollBarArea.Width;
                float scrollBarY = tblTaskContainer.Top;
                float scrollBarW = scrollBarArea.Width;
                float scrollBarH = scrollBarArea.Height;

                g.FillRectangle(scrollbarBack,scrollBarX,scrollBarY,scrollBarW,Height);

                float scrollBlockHeight =Math.Max(8f,scrollBarH / ((float)tickItems.Count) * panelItems);
                float scrollBlockPos = (scrollBarH - scrollBlockHeight) / maxPosition * position;

                g.FillRectangle(scrollbarBar, scrollBarX, scrollBarY+scrollBlockPos, scrollBarW, scrollBlockHeight);

                if (postDrag != 0) {
                    position += maxPosition / (scrollBarH - scrollBlockHeight) * (postDrag);
                    
                    postDrag = 0;
                }

                if (postSwipe != 0) {
                    if (panelLeftDown)
                    {
                        velotery = 0;
                    }
                    position += ((float)postSwipe / itemHeight);
                    postSwipe = 0;
                }


                if (position > maxPosition)
                {
                    position = maxPosition;
                }
                if (position < 0)
                {
                    position = 0;
                }
            }
            float itemBegin = (float)Math.Floor(position);
            float itemEnd = Math.Min((float)Math.Ceiling(position + panelItems), tickItems.Count-1);
            for (float f = itemBegin; f <= itemEnd; f+=1) {
                float baseX = tblTaskContainer.Left;
                float baseY = tblTaskContainer.Top + (f - position) * itemHeight;
                int itemId = (int)f;
                TickItem ti = tickItems[itemId];

                RectangleF entryArea = new RectangleF(baseX + tmpLabel.Left, baseY + tmpLabel.Top, tmpLabel.Width, tmpLabel.Height);
                
                Rectangle btnTopArea = new Rectangle((int)baseX + btnTaskTop.Left, (int)baseY + btnTaskTop.Top, btnTaskTop.Width, btnTaskTop.Height);
                Rectangle btnUpArea = new Rectangle((int)baseX + btnTaskUp.Left, (int)baseY + btnTaskUp.Top, btnTaskUp.Width, btnTaskUp.Height);
                Rectangle btnDownArea = new Rectangle((int)baseX + btnTaskDown.Left, (int)baseY + btnTaskDown.Top, btnTaskDown.Width, btnTaskDown.Height);
                Rectangle btnBottomArea = new Rectangle((int)baseX + btnTaskBottom.Left, (int)baseY + btnTaskBottom.Top, btnTaskBottom.Width, btnTaskBottom.Height);

                RectangleF buttonArea = new RectangleF(baseX + tmpButton.Left, baseY + tmpButton.Top, tmpButton.Width, tmpButton.Height);

                g.DrawString(ti.name, ti.ticked ? tmpCompleted.Font : tmpLabel.Font, fgPaint,entryArea , alignLeft);
                g.DrawImage(ti.ticked ? chk_yes : chk_no, buttonArea);

                if (isReordering)
                {
                    g.DrawImage(btnTop, btnTopArea);
                    g.DrawImage(btnUp, btnUpArea);
                    g.DrawImage(btnDown, btnDownArea);
                    g.DrawImage(btnBottom, btnBottomArea);
                }
                if ( f != itemEnd) {
                    g.DrawLine(splitItem, 0, baseY + itemHeight, Width, baseY + itemHeight);
                }

                if (postClickX != 0 && postClickY != 0) {
                    if (isReordering)
                    {

                        if (btnTopArea.Contains(postClickX, postClickY))
                        {
                            postClickY = 0; postClickX = 0;

                            tickItems.Remove(ti);
                            tickItems.Insert(0, ti);
                            refreshCountingState();
                        }

                        if (btnBottomArea.Contains(postClickX, postClickY))
                        {
                            postClickY = 0; postClickX = 0;

                            tickItems.Remove(ti);
                            tickItems.Add(ti);
                            refreshCountingState();
                        }

                        if (btnUpArea.Contains(postClickX, postClickY))
                        {
                            postClickY = 0; postClickX = 0;
                            if (itemId > 0)
                            {
                                TickItem tmp = tickItems[itemId];
                                tickItems[itemId] = tickItems[itemId - 1];
                                tickItems[itemId - 1] = tmp;
                            }
                            refreshCountingState();
                        }
                        if (btnDownArea.Contains(postClickX, postClickY))
                        {
                            postClickY = 0; postClickX = 0;
                            if (itemId < tickItems.Count - 1)
                            {
                                TickItem tmp = tickItems[itemId];
                                tickItems[itemId] = tickItems[itemId + 1];
                                tickItems[itemId + 1] = tmp;
                            }
                            refreshCountingState();
                        }
                    }
                    if (buttonArea.Contains(postClickX, postClickY))
                    {
                        postClickY = 0; postClickX = 0;
                        ti.ticked = !ti.ticked;
                        refreshCountingState();
                    }


                }
            }
            postClickY = 0; postClickX = 0;
        }

        

        class TickItem
        {
            public string name;
            public bool ticked = false;
        }



        void postAnimation(IAnimate anim) {
            lock(animations){
                animations.Add(anim);
            }
        }

        private void dragger_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dx = e.X; dy = e.Y;
        }
        bool dragging = false;
        int dx = 0, dy = 0;
        private void dragger_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging) {
                this.Left += e.X - dx;
                this.Top += e.Y - dy;
            }
        }

        bool expand = true;

        private void btnExpandable_Click(object sender, EventArgs e)
        {
            if (expand == true)
            {
                postAnimation(new IAnimate(200,delegate(float f){
                    float t =Interpolator.linear(f);
                    this.Height =(int) (panelToolbar.Bottom - ((panelToolbar.Bottom - tabPageBar.Bottom)) * t);
                    foldRotationAngel = 180f * t;
                }));
                expand = false;
                
            }
            else {
                postAnimation(new IAnimate(400, delegate (float f) {
                    float t = Interpolator.overshoot(f);
                    this.Height = (int)(tabPageBar.Bottom + (panelToolbar.Bottom - tabPageBar.Bottom) * t);
                    foldRotationAngel = 180f + 180f * t;
                }));
                expand = true;
            }

            settings.isExpanded = expand;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            postAnimation(new IAnimate(400, delegate (float f)
            {
                refreshRotationAngel = 360f * f;
            }));
            if (expand)
            {
                
                postAnimation(new IAnimate(200, delegate (float f)
                {
                    float t = Interpolator.linear(f);
                    this.Height = (int)(panelToolbar.Bottom - ((panelToolbar.Bottom - tabPageBar.Bottom)) * t);
                    foldRotationAngel = 180f * t;

                    if (f >= 1)
                    {
                        File.AppendAllLines("completed.txt", tickItems.Where(tc => tc.ticked).Select(tc => "[" + DateTime.Now.ToString() + "] " + tc.name));
                        tickItems.RemoveAll(tc => tc.ticked == true);
                        refreshCountingState();
                        postExpand = true;
                    }

                }));
                expand = false;
            }
            else {
                File.AppendAllLines("completed.txt",tickItems.Where(tc => tc.ticked).Select(t => "[" + DateTime.Now.ToString() + "] " + t.name));
                tickItems.RemoveAll(tc => tc.ticked == true);
                refreshCountingState();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            postAnimation(new IAnimate(100, delegate (float f) {
                addRotateAngel = 90f * f;
            }));
            FrmAddTask frm = new FrmAddTask();
            if (frm.ShowDialog() == DialogResult.OK) {
                String[] tasks = frm.textBox1.Lines;
                foreach (string task in tasks)
                {
                    string t = task.Trim();
                    if (t.Length > 0) {
                        tickItems.Add(new TickItem() { name = t });
                    }
                } 
            }
            refreshCountingState();
            frm.Dispose();
        }

        private void scrollBarArea_MouseDown(object sender, MouseEventArgs e)
        {
            isDragging = true;
            beginDragY = e.Y;
        }
        int beginDragY;
        bool isDragging = false;
        private void scrollBarArea_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging) {
                dy = e.Y - beginDragY;
                postDrag += dy;
                beginDragY = e.Y;
            }
        }

        private void scrollBarArea_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }

        
        private void tblTaskContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCompleteFirst_Click(object sender, EventArgs e)
        {
            tickItems.First(t => t.ticked == false).ticked = true;
            btnCompleteFirst.Enabled = false;
            postAnimation(new IAnimate(500, delegate (float f) {
                if (f >= 1) {
                    btnCompleteFirst.Enabled = true;
                    refreshCountingState();
                }
            }));
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {
            GC.Collect();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveConf();
            Application.Exit();
        }

        private void gcTimer_Tick(object sender, EventArgs e)
        {
            GC.Collect();
        }

        

        private void tblTaskContainer_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (lenLine(e.Location, panelDownPoint) < 3)
                {
                    postClickX = tblTaskContainer.Left + e.X;
                    postClickY = tblTaskContainer.Top + e.Y;
                }
                else {
                    velotery = ((float)deltaY) / 24;
                }
                panelLeftDown = false;
            }
        }


        int lenLine(Point p1, Point p2) {
            int x1 = p1.X, x2 = p2.X, y1 = p1.Y, y2 = p2.Y;
            return (int)Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
        }


        Point panelDownPoint = Point.Empty;

        bool panelLeftDown = false;

        int deltaY = 0;

        private void tblTaskContainer_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                panelDownPoint = e.Location;
                panelLastPoint = e.Location;
                panelLeftDown = true;
            }
        }


        Point panelLastPoint = Point.Empty;
        private void tblTaskContainer_MouseMove(object sender, MouseEventArgs e)
        {
            if (panelLeftDown) {
                postSwipe = -(e.Y - panelLastPoint.Y);
                deltaY = postSwipe;
                panelLastPoint = e.Location;
            }
            this.ActiveControl = tblTaskContainer;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            settings.Save();
        }

        private void optacy_Click(object sender, EventArgs e)
        {
            int alpha = int.Parse(((ToolStripMenuItem)sender).Tag.ToString());
            bgPaint = new SolidBrush(Color.FromArgb(alpha, Color.Black));
            backgroundColor = Color.FromArgb(alpha, Color.Black);
            settings.backgroundOptacy = alpha;

        }

        bool isReordering = false;

        private void btnReorder_Click(object sender, EventArgs e)
        {
            isReordering = !isReordering;
        }

        private void dragger_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
            settings.windowPosition = Location;
        }
    }

    public class IAnimate {
        public float duration;
        private float position = 0;
        public bool finished = false;

        public Action<float> animAction;

        public IAnimate(float duration,Action<float> animAction)
        {
            this.duration = duration;
            this.animAction = animAction;
        }
        
        internal void processAnimaFrame() {
            position += 1f / (duration / 16.6666666f);
            if (position > 1) { position = 1;finished = true; }
            animAction.Invoke(position);
        }

    }


    class Interpolator
    {

        public const int LINEAR = 0;
        public const int OVERSHOOT = 1;
        public const int ANTICIPATE = 2;
        public const int ANTICIPATE_OVERSHOOT = 3;
        public const int BUMP = 4;
        public static float callInterpolator(float x, int type)
        {
            switch (type)
            {
                case LINEAR: return linear(x);
                case OVERSHOOT: return overshoot(x);
                case ANTICIPATE: return anticipate(x);
                case ANTICIPATE_OVERSHOOT: return anticipate_overshoot(x);
                case BUMP: return bump(x);
                default: throw new InvalidEnumArgumentException();
            }
        }

        public static float linear(float x)
        {
            if (x < 0) { return 0; }
            if (x > 1) { return 1; }
            return x;
        }

        public static float overshoot(float x)
        {
            if (x < 0) { return 0; }
            if (x > 1) { return 1; }
            return (x - 1) * (x - 1) * ((2 + 1) * (x - 1) + 2) + 1;
        }

        public static float anticipate(float x)
        {
            if (x < 0) { return 0; }
            if (x > 1) { return 1; }
            return x * x * ((2 + 1) * x - 2);
        }
        public static float anticipate_overshoot(float x)
        {
            if (x < 0) { return 0; }
            if (x > 1) { return 1; }
            if (x < 0.5)
            {
                return 0.5f * 2f * x * 2f * x * ((3f + 1f) * 2f * x - 3f);
            }
            return 0.5f * ((2 * x - 2) * (2 * x - 2) * ((3 + 1) * (2 * x - 2) + 3) + 2);
        }
        public static float bump(float x)
        {
            if (x <= 0) { return 0; }
            if (x >= 1) { return 1; }
            return ((float)-Math.Cos(2.5 * Math.PI * x)) * (1 - (float)Math.Sqrt(x)) + 1;
        }
    }
}
