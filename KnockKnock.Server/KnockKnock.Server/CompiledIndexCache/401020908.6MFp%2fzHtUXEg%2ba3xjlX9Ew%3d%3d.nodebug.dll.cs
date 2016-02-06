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

public class Index_Knock_ByFeed : Raven.Database.Linq.AbstractViewGenerator
{
	public Index_Knock_ByFeed()
	{
		this.ViewText = @"from knock in docs.Knocks
select new {
	FeedId = knock.FeedId
}";
		this.ForEntityNames.Add("Knocks");
		this.AddMapDefinition(docs => 
			from knock in ((IEnumerable<dynamic>)docs)
			where string.Equals(knock["@metadata"]["Raven-Entity-Name"], "Knocks", System.StringComparison.InvariantCultureIgnoreCase)
			select new {
				FeedId = knock.FeedId,
				__document_id = knock.__document_id
			});
		this.AddField("FeedId");
		this.AddField("__document_id");
		this.AddQueryParameterForMap("FeedId");
		this.AddQueryParameterForMap("__document_id");
		this.AddQueryParameterForReduce("FeedId");
		this.AddQueryParameterForReduce("__document_id");
	}
}
