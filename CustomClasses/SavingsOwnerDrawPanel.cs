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
    public class SavingsOwnerDrawPanel : Panel
    {
        public class SavingsRow
        {
            public int Sid { get; set; }
            public string Timestamp { get; set; }
            public double Amount { get; set; }
        }

        private List<SavingsRow> _rows = new List<SavingsRow>();
        private int? _selectedIndex = null;
        private int _rowHeight = 45;
        private int _rowSpacing = 8;
        private int _leftPad = 10;
        private int _dateWidth = 90;
        private int _amountWidth = 130;
        private Font _font = new Font("Microsoft Sans Serif", 12F);
        private Color _rowBack = Color.White;
        private Color _rowFore = Color.FromArgb(64, 64, 64);
        private Color _rowBorder = Color.FromArgb(224, 224, 224);
        private Color _rowUnderline = Color.MediumSlateBlue;
        private Color _selectedBack = Color.FromArgb(74, 183, 255);
        private Color _selectedFore = Color.White;

        public event EventHandler SelectedRowChanged;

        [Browsable(false)]
        public int? SelectedIndex => _selectedIndex;
        [Browsable(false)]
        public SavingsRow SelectedRow => (_selectedIndex != null && _selectedIndex >= 0 && _selectedIndex < _rows.Count) ? _rows[_selectedIndex.Value] : null;

        public SavingsOwnerDrawPanel()
        {
            this.DoubleBuffered = true;
            this.AutoScroll = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.BackColor = Color.White;
            this.Cursor = Cursors.Hand;
        }

        public void SetRows(IEnumerable<SavingsRow> rows)
        {
            _rows = rows.ToList();
            _selectedIndex = null;
            Invalidate();
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
                using (Pen p = new Pen(_rowUnderline, 2))
                    g.DrawLine(p, rowRect.Left, rowRect.Bottom - 2, rowRect.Right, rowRect.Bottom - 2);
                // Border
                using (Pen p = new Pen(_rowBorder, 1))
                    g.DrawRectangle(p, rowRect);
                // Date
                using (Brush b = new SolidBrush(selected ? _selectedFore : _rowFore))
                    g.DrawString(row.Timestamp, _font, b, rowRect.Left + 10, rowRect.Top + 10);
                // Amount
                string amt = "₱" + row.Amount.ToString("0.00");
                g.DrawString(amt, _font, selected ? Brushes.White : new SolidBrush(_rowFore), rowRect.Left + _dateWidth + 30, rowRect.Top + 10);
                y += _rowHeight + _rowSpacing;
            }
            // Set scrollable area
            this.AutoScrollMinSize = new Size(0, _rows.Count * (_rowHeight + _rowSpacing) + _rowSpacing);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
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

        // Deselect if clicked outside panel
        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            if (_selectedIndex != null)
            {
                _selectedIndex = null;
                SelectedRowChanged?.Invoke(this, EventArgs.Empty);
                Invalidate();
            }
        }
    }
} 