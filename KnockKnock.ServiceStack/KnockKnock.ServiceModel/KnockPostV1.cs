﻿using ServiceStack.ServiceHost;

namespace KnockKnock.ServiceModel
{

    [Route("/api/v1/knocks/", "POST, PUT")]
    public class KnockPostV1 : IReturn<long>
    {
        public Types.KnockDto Knock { get; set; }
    }
}
