using System.Collections.Generic;
using AutoMapper.Internal;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using Umbraco.Core.Models;
using UmbracoExport.Core.Models;

namespace UmbracoExport.Core.Extentions
{
    public static class UmbracoExtentions
    {
        public static NodeContent GetAllNodes(this IPublishedContent value)
        {
            var nodeContent = NodeContent.ToNodeContent(value);
            nodeContent.Properties.AddRange(value.Properties.Select(NodeProperty.ToNodeProperty));
            BuildNodes(value, nodeContent);
            return nodeContent;
        }

        public static IEnumerable<NodeFlatContent> GetAllNodesFlat(this IPublishedContent value)
        {
            IList<NodeFlatContent> list = new List<NodeFlatContent>();
            list.Add(NodeFlatContent.ToNodeFlatContent(value));
            BuildFlat(value, list);
            return list;
        }

        private static void BuildNodes(IPublishedContent node, NodeContent nodeContent)
        {
            foreach (var child in node.Children)
            {
                var ncChild = NodeContent.ToNodeContent(child);
                ncChild.Properties.AddRange(child.Properties.Select(NodeProperty.ToNodeProperty));
                nodeContent.Children.Add(ncChild);

                if (child.Children.Any())
                {
                    BuildNodes(child, ncChild);
                }
            }
        }

        private static void BuildFlat(IPublishedContent node, ICollection<NodeFlatContent> list)
        {
            foreach (var child in node.Children)
            {
                list.Add(NodeFlatContent.ToNodeFlatContent(child));
                if (child.Children.Any())
                {
                    BuildFlat(child, list);
                }
            }
        }

    }
}