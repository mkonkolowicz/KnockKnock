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

public class Index_Knock_ByLocation : Raven.Database.Linq.AbstractViewGenerator
{
	public Index_Knock_ByLocation()
	{
		this.ViewText = @"from knock in docs.Knocks
select new {
	_ = SpatialGenerate(""Location"", ((double?)knock.Location.Latitude), ((double?)knock.Location.Longitude))
}";
		this.ForEntityNames.Add("Knocks");
		this.AddMapDefinition(docs => 
			from knock in ((IEnumerable<dynamic>)docs)
			where string.Equals(knock["@metadata"]["Raven-Entity-Name"], "Knocks", System.StringComparison.InvariantCultureIgnoreCase)
			select new {
				_ = SpatialGenerate("Location", ((double?)knock.Location.Latitude), ((double?)knock.Location.Longitude)),
				__document_id = knock.__document_id
			});
		this.AddField("_");
		this.AddField("__document_id");
		this.AddQueryParameterForMap("__document_id");
		this.AddQueryParameterForReduce("__document_id");
	}
}
