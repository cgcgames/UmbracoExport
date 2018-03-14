using System;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Core.Models;

namespace UmbracoExport.Core.Models
{
    public class NodeFlatContent
    {
        public int Id { get; set; }
        public string CreatorName { get; set; }
        public int CreatorId { get; set; }
        public string DocumentTypeAlias { get; set; }
        public int DocumentTypeId { get; set; }
        public int Level { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string Url { get; set; }
        public int TemplateId { get; set; }
        public bool IsDraft { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public static NodeFlatContent ToNodeFlatContent(IPublishedContent node)
        {
            return new NodeFlatContent
            {
                Id = node.Id,
                CreatorName = node.CreatorName,
                CreatorId = node.CreatorId,
                DocumentTypeAlias = node.DocumentTypeAlias,
                DocumentTypeId = node.DocumentTypeId,
                Level = node.Level,
                Name = node.Name,
                Path = node.Path,
                Url = node.Url,
                TemplateId = node.TemplateId,
                IsDraft = node.IsDraft,
                CreatedDate = node.CreateDate,
                UpdatedDate = node.UpdateDate
            };
        }
    }
}