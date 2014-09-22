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
using ArcGIS.Desktop.Internal.Mapping;
using ArcGIS.Core.CIM;
using ArcGIS.Desktop.Internal.Mapping.Symbology;
using ArcGIS.Desktop.Mapping.Symbology;

namespace ProAppModule1
{
    internal class Button1 : Button
    {
        /// <summary>
        /// Button click method. Chnage synbology of a featurelayer called "counties from the all the maps which has a "POP2000" field. It creates a class break symbology.
        /// </summary>
        protected override void OnClick()
        {
      
            //get assess to map objects
               foreach (Map map in ArcGIS.Desktop.Mapping.MappingModule.Maps)
               {
                   //loop through the mapviews
                   foreach (MapView mapView in ArcGIS.Desktop.Mapping.MappingModule.GetMapViews(map))
                   {
                      
                  
                       FeatureLayer m_Layer = new FeatureLayer();
                       //check if they are layers in the mapview
                       if (map.InternalLayers.Count > 0)
                       {
                           //check if the layer is a feature layer
                           if (map.InternalLayers[0] is FeatureLayer)
                           {

                           
                            m_Layer = map.InternalLayers[0] as FeatureLayer;
                                //check if the layer name is counties
                                if( m_Layer.Name == "counties")
                                {

                                    ArcGIS.Core.CIM.CIMFeatureDatasetDataConnection dataConnection = m_Layer.DataConnection as ArcGIS.Core.CIM.CIMFeatureDatasetDataConnection;

                    
                                    CIMClassBreaksRenderer m_CIMClassBreaksRenderer = new CIMClassBreaksRenderer();               
                                    CIMClassBreak[] m_CIMClassBreak = new CIMClassBreak[5];
                     
                          
                                    m_CIMClassBreaksRenderer.Field = "POP2000";
                                    m_CIMClassBreaksRenderer.ClassificationMethod = ClassificationMethod.Quantile;
                                    m_CIMClassBreaksRenderer.NormalizationType = DataNormalizationMethod.Nothing;
                                    m_CIMClassBreaksRenderer.ClassBreakType = ClassBreakType.GraduatedColor;
                                    m_CIMClassBreaksRenderer.MinimumBreakSpecified = false;
                                    m_CIMClassBreaksRenderer.UseExclusionSymbol = false;
                     
                                    ArcGIS.Core.CIM.CIMLinearContinuousColorRamp m_CIMColorRamp = new ArcGIS.Core.CIM.CIMLinearContinuousColorRamp();

                                    ArcGIS.Core.CIM.CIMRGBColor m_Color = new ArcGIS.Core.CIM.CIMRGBColor();
                                    m_Color.R = 0;
                                    m_Color.B =0;
                                    m_Color.G =255;

                                    ArcGIS.Core.CIM.CIMRGBColor m_Color1 = new ArcGIS.Core.CIM.CIMRGBColor();
                                    m_Color1.R = 255;
                                    m_Color1.B = 0;
                                    m_Color1.G = 0;
                      
                                    m_CIMColorRamp.FromColor = m_Color as CIMColor;
                                    m_CIMColorRamp.ToColor = m_Color1 as CIMColor;
                          
                                    m_CIMClassBreaksRenderer.ColorRamp = m_CIMColorRamp;
                 
                                    for (int i = 0; i < 5; i++)
                                    {

                                        CIMClassBreak m_CIMClassBreak1 = new CIMClassBreak();
                               
                                        m_CIMClassBreak1.UpperBound = (i * 900000) + 165415;
                                        m_CIMClassBreak1.CriticalBreak = false;
                                        m_CIMClassBreak1.UpperBoundSpecified = true;
                                        m_CIMClassBreak1.Patch = ArcGIS.Core.CIM.PatchShape.AreaRectangle;
                                        m_CIMClassBreak1.Label = "";
                                        m_CIMClassBreak1.Description = "";

                                        ArcGIS.Core.CIM.CIMRGBColor temp_Color1 = new ArcGIS.Core.CIM.CIMRGBColor();
                                        temp_Color1.R = 20 + 20 * i;
                                        temp_Color1.B = 20 + 20 * i;
                                        temp_Color1.G = 20 + 20 * i;
                                        CIMSymbol m_CIMSymbol1 = ArcGIS.Desktop.Mapping.Symbology.SymbolHelper.ConstructPolygonSymbol(ColorHelper.GetRampColor(m_CIMColorRamp,(double)(i*2)/10), ArcGIS.Desktop.Mapping.Symbology.SymbolHelper.DefaultFillStyle) as CIMSymbol;
                                        CIMSymbolReference m_CIMSymbolReference = new CIMSymbolReference();
                                        m_CIMSymbolReference.Symbol = m_CIMSymbol1;
                               
                                        m_CIMClassBreak1.Symbol = m_CIMSymbolReference;
                                        m_CIMClassBreak[i] = m_CIMClassBreak1;

                           }

                           m_CIMClassBreaksRenderer.Breaks = m_CIMClassBreak;
                           m_Layer.UpdateRenderer(m_CIMClassBreaksRenderer);

                       
                     }
                           }
                       }
                   }
                  
               }
          
        }
    }
}
