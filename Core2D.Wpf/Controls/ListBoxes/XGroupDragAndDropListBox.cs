﻿// Copyright (c) Wiesław Šoltés. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
using System;
using System.Collections.Immutable;
using System.Windows.Controls;

namespace Core2D.Wpf.Controls
{
    /// <summary>
    /// The <see cref="ListBox"/> control for <see cref="XGroup"/> items with drag and drop support.
    /// </summary>
    public class XGroupDragAndDropListBox : DragAndDropListBox<XGroup>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="XGroupDragAndDropListBox"/> class.
        /// </summary>
        public XGroupDragAndDropListBox()
            : base()
        {
            this.Initialized += (s, e) => base.Initialize();
        }

        /// <summary>
        /// Updates DataContext collection ImmutableArray property.
        /// </summary>
        /// <param name="array">The updated immutable array.</param>
        public override void UpdateDataContext(ImmutableArray<XGroup> array)
        {
            var editor = (Editor)this.Tag;

            var gl = editor.Project.CurrentGroupLibrary;

            if (editor.EnableHistory)
            {
                var previous = gl.Items;
                var next = array;
                editor.History.Snapshot(previous, next, (p) => gl.Items = p);
                gl.Items = next;
            }
            else
            {
                gl.Items = array;
            }
        }
    }
}