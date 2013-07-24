using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using N2;
using N2.Details;
using N2.Web.UI;
using N2.Integrity;
using N2.Definitions;

namespace Dinamico.Models
{
	/// <summary>
	/// Base implementation for pages on a dinamico site.
	/// </summary>
	[WithEditableTitle]
	[WithEditableName(ContainerName = Defaults.Containers.Metadata)]
	[WithEditableVisibility(ContainerName = Defaults.Containers.Metadata)]
	[SidebarContainer(Defaults.Containers.Metadata, 100, HeadingText = "Metadata")]
	[TabContainer(Defaults.Containers.Content, "Content", 1000)]
	[RestrictParents(typeof(IPage))]
	public abstract class PageModelBase : ContentItem, IPage
	{

        [EditableCheckBox(ContainerName = Defaults.Containers.Metadata, CheckBoxText = "Display children in nav.")]
        public bool ConsiderChildrenInTopNav
        {
            get { return GetDetail<bool>("ConsiderChildrenInTopNav", true); }
            set { SetDetail("ConsiderChildrenInTopNav", value, true); }
        }

        [EditableCheckBox(ContainerName = Defaults.Containers.Metadata, CheckBoxText = "Display logo")]
        public bool DisplayLogo
        {
            get { return GetDetail<bool>("DisplayLogo", true); }
            set { SetDetail("DisplayLogo", value, true); }
        }

        

	}
}