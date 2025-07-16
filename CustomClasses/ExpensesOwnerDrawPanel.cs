using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using SavexTracker.Models;

namespace SavexTracker.CustomClasses
{
    public class ExpensesOwnerDrawPanel : Panel
    {
        public class ExpensesRow
        {
            public int Eid { get; set; }
            public string Timestamp { get; set; }
            public double Amount { get; set; }
            public string Note { get; set; }
        }

        private List<ExpensesRow> _rows = new List<ExpensesRow>();
        private int? _selectedIndex = null;
        private int _rowHeight = 45;
        private int _rowSpacing = 8;
        private int _leftPad = 10;
        private int _dateWidth = 90;
        private int _amountWidth = 110;        
        private Font _font = new Font("Microsoft Sans Serif", 12F);
        private Font _buttonFont = new Font("Noto Sans", 10F);
        private Color _rowBack = Color.White;
        private Color _rowFore = Color.FromArgb(64, 64, 64);
        private Color _selectedBack = Color.FromArgb(74, 183, 255);
        private Color _selectedFore = Color.White;
        private int? _hoveredRow = null;
        private bool _hoveredButton = false;
        private Rectangle _buttonRect = Rectangle.Empty;
        public event EventHandler<int> RowModifyRequested;
        public event EventHandler SelectedRowChanged;

        [Browsable(false)]
        public int? SelectedIndex => _selectedIndex;
        [Browsable(false)]
        public ExpensesRow SelectedRow => (_selectedIndex != null && _selectedIndex >= 0 && _selectedIndex < _rows.Count) ? _rows[_selectedIndex.Value] : null;

        public ExpensesOwnerDrawPanel()
        {
            this.DoubleBuffered = true;
            this.AutoScroll = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.BackColor = Color.White;
            this.Cursor = Cursors.Hand;
        }

        public void SetRows(IEnumerable<ExpensesRow> rows)
        {
            _rows = rows.ToList();
            _selectedIndex = null;
            Invalidate();
        }

        public ExpensesRow GetRow(int index)
        {
            if (index >= 0 && index < _rows.Count)
                return _rows[index];
            return null;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            int y = this.AutoScrollPosition.Y + _rowSpacing;
            for (int i = 0; i < _rows.Count; i++)
            {
                var row = _rows[i];
                Rectangle rowRect = new Rectangle(_leftPad, y, this.Width - 2 * _leftPad, _rowHeight);
                bool selected = (_selectedIndex == i);
                // Background
                using (Brush b = new SolidBrush(selected ? _selectedBack : _rowBack))
                    g.FillRectangle(b, rowRect);
                // Underline
                using (Pen p = new Pen(Color.Silver, 1))
                    g.DrawLine(p, rowRect.Left, rowRect.Bottom - 1, rowRect.Right, rowRect.Bottom - 1);
                // Date
                using (Brush b = new SolidBrush(selected ? _selectedFore : _rowFore))
                    g.DrawString(row.Timestamp, _font, b, rowRect.Left + 10, rowRect.Top + 10);
                // Amount
                string amt = "₱" + row.Amount.ToString("0.00");
                g.DrawString(amt, _font, selected ? Brushes.White : new SolidBrush(_rowFore), rowRect.Left + _dateWidth + 20, rowRect.Top + 10);
                // Note
                g.DrawString(row.Note, _font, selected ? Brushes.White : new SolidBrush(_rowFore), rowRect.Left + _dateWidth + _amountWidth + 30, rowRect.Top + 10);
                // Draw Modify button if hovered
                if (_hoveredRow == i)
                {
                    int btnWidth = 70, btnHeight = 28;
                    int btnX = rowRect.Right - btnWidth - 10;
                    int btnY = rowRect.Top + (rowRect.Height - btnHeight) / 2;
                    _buttonRect = new Rectangle(btnX, btnY, btnWidth, btnHeight);
                    Color btnColor = _hoveredButton ? Color.FromArgb(106, 90, 205) : Color.LightGray;
                    using (Brush bb = new SolidBrush(btnColor))
                        g.FillRectangle(bb, _buttonRect);
                    // No border
                    using (StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                        g.DrawString("Modify", _buttonFont, Brushes.White, _buttonRect, sf);
                }
                y += _rowHeight + _rowSpacing;
            }
            // Set scrollable area
            this.AutoScrollMinSize = new Size(0, _rows.Count * (_rowHeight + _rowSpacing) + _rowSpacing);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            int y = this.AutoScrollPosition.Y + _rowSpacing;
            bool found = false;
            for (int i = 0; i < _rows.Count; i++)
            {
                Rectangle rowRect = new Rectangle(_leftPad, y, this.Width - 2 * _leftPad, _rowHeight);
                int btnWidth = 70, btnHeight = 28;
                int btnX = rowRect.Right - btnWidth - 10;
                int btnY = rowRect.Top + (rowRect.Height - btnHeight) / 2;
                Rectangle btnRect = new Rectangle(btnX, btnY, btnWidth, btnHeight);
                if (rowRect.Contains(e.Location))
                {
                    if (_hoveredRow != i || _buttonRect != btnRect)
                    {
                        _hoveredRow = i;
                        _buttonRect = btnRect;
                        _hoveredButton = btnRect.Contains(e.Location);
                        Invalidate();
                    }
                    else
                    {
                        bool prevHover = _hoveredButton;
                        _hoveredButton = btnRect.Contains(e.Location);
                        if (prevHover != _hoveredButton) Invalidate();
                    }
                    found = true;
                    break;
                }
                y += _rowHeight + _rowSpacing;
            }
            if (!found && _hoveredRow != null)
            {
                _hoveredRow = null;
                _hoveredButton = false;
                Invalidate();
            }
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            if (_hoveredRow != null && _buttonRect.Contains(e.Location))
            {
                RowModifyRequested?.Invoke(this, _hoveredRow.Value);
                return;
            }
            int y = this.AutoScrollPosition.Y + _rowSpacing;
            for (int i = 0; i < _rows.Count; i++)
            {
                Rectangle rowRect = new Rectangle(_leftPad, y, this.Width - 2 * _leftPad, _rowHeight);
                if (rowRect.Contains(e.Location))
                {
                    if (_selectedIndex != i)
                    {
                        _selectedIndex = i;
                        SelectedRowChanged?.Invoke(this, EventArgs.Empty);
                        Invalidate();
                    }
                    return;
                }
                y += _rowHeight + _rowSpacing;
            }
            // Clicked outside any row
            if (_selectedIndex != null)
            {
                _selectedIndex = null;
                SelectedRowChanged?.Invoke(this, EventArgs.Empty);
                Invalidate();
            }
        }
    }
} 