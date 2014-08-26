using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArcGIS.Desktop.Framework;
using ArcGIS.Desktop.Framework.Contracts;
using ArcGIS.Desktop.Core;
using ArcGIS.Desktop.Mapping;
using ArcGIS.Desktop.Catalog;

namespace ProAppModule1
{
    internal class Button1 : Button
    {
        protected override void OnClick()
        {
            Project m_Project = ArcGIS.Desktop.Core.ProjectModule.CurrentProject;
            

            ArcGIS.Desktop.Mapping.MapContainer mapContainer = m_Project.GetProjectItemContainer("Map") as ArcGIS.Desktop.Mapping.MapContainer;
            ArcGIS.Desktop.GeoProcessing.GeoprocessingContainer m_GeoprocessingContainer = m_Project.GetProjectItemContainer("GP") as ArcGIS.Desktop.GeoProcessing.GeoprocessingContainer;
            ArcGIS.Desktop.Catalog.GDBContainer m_GDBContainer = m_Project.GetProjectItemContainer("GDB") as ArcGIS.Desktop.Catalog.GDBContainer;
            ArcGIS.Desktop.Catalog.FolderConnectionContainer m_FolderConnectionContainer = m_Project.GetProjectItemContainer("FolderConnection") as ArcGIS.Desktop.Catalog.FolderConnectionContainer;
            ArcGIS.Desktop.Core.DisplayUnitEnvironmentItemContainer m_DisplayUnitEnvironmentItemContainer = m_Project.GetProjectItemContainer("DisplayUnitEnvironment") as ArcGIS.Desktop.Core.DisplayUnitEnvironmentItemContainer;
            ArcGIS.Desktop.Mapping.StyleContainer m_StyleContainer = m_Project.GetProjectItemContainer("Styles") as ArcGIS.Desktop.Mapping.StyleContainer;
            
           

            foreach (MapProjectItem item in mapContainer.GetProjectItems())
            {
            
               // ArcGIS.Desktop.Internal.Framework.Metro.MessageBox.Show(item.Name);

            }

            foreach (FolderConnectionProjectItem folderitem in m_FolderConnectionContainer.GetProjectItems())
            {

                ArcGIS.Desktop.Internal.Framework.Metro.MessageBox.Show(folderitem.Name);
            }
        }
    }
}
