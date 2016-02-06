using Raven.Abstractions;
using Raven.Database.Linq;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using System;
using Raven.Database.Linq.PrivateExtensions;
using Lucene.Net.Documents;
using System.Globalization;
using System.Text.RegularExpressions;
using Raven.Database.Indexing;

public class Index_Feed_ByLocationAndName : Raven.Database.Linq.AbstractViewGenerator
{
	public Index_Feed_ByLocationAndName()
	{
		this.ViewText = @"from feed in docs.Feeds
select new {
	_ = SpatialGenerate(""Location"", ((double?)feed.Location.Latitude), ((double?)feed.Location.Longitude)),
	Name = feed.Name
}";
		this.ForEntityNames.Add("Feeds");
		this.AddMapDefinition(docs => 
			from feed in ((IEnumerable<dynamic>)docs)
			where string.Equals(feed["@metadata"]["Raven-Entity-Name"], "Feeds", System.StringComparison.InvariantCultureIgnoreCase)
			select new {
				_ = SpatialGenerate("Location", ((double?)feed.Location.Latitude), ((double?)feed.Location.Longitude)),
				Name = feed.Name,
				__document_id = feed.__document_id
			});
		this.AddField("_");
		this.AddField("Name");
		this.AddField("__document_id");
		this.AddQueryParameterForMap("Name");
		this.AddQueryParameterForMap("__document_id");
		this.AddQueryParameterForReduce("Name");
		this.AddQueryParameterForReduce("__document_id");
	}
}
