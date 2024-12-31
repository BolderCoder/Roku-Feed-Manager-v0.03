# Roku Feed Manager v0.03

_Windows Forms application to create, validate, and modify Roku Direct Publisher Feed files._

Created: 2024-12-30
Updated: 2024-12-30

<p>This application is designed to maintain a content database to swiftly produce and modify Roku Direct Publisher Feed files used in populating the content of Roku channels. This file in JSON format contains metadata for every video served through the Roku platform.</p>

https://developer.roku.com/docs/specs/direct-publisher-feed-specs/json-dp-spec.md#direct-publisher-feed-schema

This application features a database of video, audio, and graphic assets with a tree structure for asset management. The user can maintain several channels through the application.

## Development Steps

Data Definition:  
  - Define the core JSON structure as C# classes.
  - Define a relational database containing the content data.

Create a management console with the following features:
  - Creation, modification, and deletion of Channels and JSON feeds.
  - Creation, modification, and deletion of Content assets

## Representing the feed's JSON schema as a C# Class

### root
<table>
<tr>
<td><p>Field</p></td>
<td><p>Type</p></td>
<td><p>Required</p></td>
<td><p>Description</p></td>
</tr>
  
  <tr><td><p>providerName</p></td><td><p>string</p></td><td><p>Required</p></td><td><p>The name of the feed provider. E.g.: &ldquo;Acme Productions&rdquo;.</p></td></tr>
  <tr><td><p>lastUpdated</p></td><td><p>string</p></td><td><p>Required</p></td><td><p>The date that the feed was last modified in<a href="https://www.google.com/url?q=http://www.iso.org/iso/home/standards/iso8601.htm&amp;sa=D&amp;source=editors&amp;ust=1735580039363387&amp;usg=AOvVaw0DEQlGOPjBW_7SY8aSieqv">&nbsp;</a><a href="https://www.google.com/url?q=http://www.iso.org/iso/home/standards/iso8601.htm&amp;sa=D&amp;source=editors&amp;ust=1735580039363523&amp;usg=AOvVaw2An-CzaSNnFzZUljZmvDIb">ISO 8601</a>&nbsp;format: {YYYY}-{MM}-{DD}T{hh}:{mm}:{ss}+{TZ}. For example, 2020-11-11T22:21:37+00:00</p></td></tr>
  <tr><td><p>language</p></td><td><p>string</p></td><td><p>Required</p></td><td><p>The language the channel uses for all its information and descriptions. (e.g., &ldquo;en&rdquo;, &ldquo;en-US&rdquo;, &ldquo;es&rdquo;, etc.). ISO 639 alpha-2 or alpha-3 language code string.</p></td></tr>
  <tr><td><p>movies</p></td><td><p><a href="https://www.google.com/url?q=https://developer.roku.com/docs/specs/direct-publisher-feed-specs/json-dp-spec.md%23movie&amp;sa=D&amp;source=editors&amp;ust=1735580039365214&amp;usg=AOvVaw0HQkXUt0baoMxcSI451Kdr">Movie Object</a></p></td><td><p>Required*</p></td><td><p>A list of one or more movies.</p></td></tr>
  <tr><td><p>liveFeeds</p></td><td><p><a href="https://www.google.com/url?q=https://developer.roku.com/docs/specs/direct-publisher-feed-specs/json-dp-spec.md%23livefeed&amp;sa=D&amp;source=editors&amp;ust=1735580039366320&amp;usg=AOvVaw0-iUwW8o_VF3fzK7iTKXgZ">LiveFeeds Object</a></p></td><td><p>Required*</p></td><td><p>A list of one or more live linear streams.</p></td></tr>
  <tr><td><p>series</p></td><td><p><a href="https://www.google.com/url?q=https://developer.roku.com/docs/specs/direct-publisher-feed-specs/json-dp-spec.md%23series&amp;sa=D&amp;source=editors&amp;ust=1735580039367322&amp;usg=AOvVaw3ihz2aXVFkF2QxPr9yPsgJ">Series Object</a></p></td><td><p>Required*</p></td><td><p>A list of one or more series. Series are episodic in nature and would include TV shows, daily/weekly shows, etc.</p></td></tr>
  <tr><td><p>shortFormVideos</p></td><td><p><a href="https://www.google.com/url?q=https://developer.roku.com/docs/specs/direct-publisher-feed-specs/json-dp-spec.md%23shortformvideo&amp;sa=D&amp;source=editors&amp;ust=1735580039368311&amp;usg=AOvVaw3Lvj2tW2-8eeTOjoQb-JLn">ShortFormVideo Object</a></p></td><td><p>Required*</p></td><td><p>A list of one or more short-form videos. Short-form videos are usually less than 15 minutes long and are not TV Shows or Movies.</p></td></tr>
  <tr><td><p>tvSpecials</p></td><td><p><a href="https://www.google.com/url?q=https://developer.roku.com/docs/specs/direct-publisher-feed-specs/json-dp-spec.md%23tvspecial&amp;sa=D&amp;source=editors&amp;ust=1735580039369313&amp;usg=AOvVaw0EbFYN1Z6tF_r5dOCUSUOZ">TV Special Object</a></p></td><td><p>Required*</p></td><td><p>A list of one or more TV Specials. TV Specials are one-time TV programs that are not part of a series.</p></td></tr>
  <tr><td><p>categories</p></td><td><p><a href="https://www.google.com/url?q=https://developer.roku.com/docs/specs/direct-publisher-feed-specs/json-dp-spec.md%23category&amp;sa=D&amp;source=editors&amp;ust=1735580039370300&amp;usg=AOvVaw1RJkNiWQgoFfJIFZ6BMsst">Category Object</a></p></td><td><p>Optional</p></td><td><p>An ordered list of one or more categories that will show up in your Roku Channel. Categories may also be manually specified within Direct Publisher if you do not want to provide them directly in the feed. Each time the feed is updated it will refresh the categories.</p></td></tr>
  <tr><td><p>playlists</p></td><td><p><a href="https://www.google.com/url?q=https://developer.roku.com/docs/specs/direct-publisher-feed-specs/json-dp-spec.md%23playlist&amp;sa=D&amp;source=editors&amp;ust=1735580039371273&amp;usg=AOvVaw0P_XuszUkhUik4dZYihkCt">Playlist Object</a></p></td><td><p>Optional</p></td><td><p>A list of one or more playlists. They are useful for creating manually ordered categories inside your channel.</p></td></tr>
</table>

### movie
<table>
<tr>
<td><p>Field</p></td>
<td><p>Type</p></td>
<td><p>Required</p></td>
<td><p>Description</p></td>
</tr>

<tr class="c22"><td class="c12"><p class="c0"><span class="c3">id</span></p></td><td class="c8 c24"><p class="c0"><span class="c3">string</span></p></td><td class="c5"><p class="c0"><span class="c3">Required</span></p></td><td class="c16 c24"><p class="c0"><span class="c3 c4">An immutable string reference ID for the movie that does not exceed 50 characters. This should serve as a unique identifier for the movie across different locales.</span></p><p class="c0"><span class="c3">Once created, the ID for the content item may not be changed.</span></p></td></tr>

<tr class="c15"><td class="c13"><p class="c0"><span class="c3">title</span></p></td><td class="c8 c14"><p class="c0"><span class="c3">string</span></p></td><td class="c2"><p class="c0"><span class="c3">Required</span></p></td><td class="c9"><p class="c0"><span class="c3">The movie title in plain text. This field is used for matching in Roku Search. Do not include extra information such as year, version label, and so on.</span></p></td></tr>

<tr class="c10"><td class="c12"><p class="c0"><span class="c3">content</span></p></td><td class="c8"><p class="c0"><span class="c11"><a class="c7" href="https://www.google.com/url?q=https://developer.roku.com/docs/specs/direct-publisher-feed-specs/json-dp-spec.md%23content&amp;sa=D&amp;source=editors&amp;ust=1735580784442829&amp;usg=AOvVaw2mJTfn7lOnctlQo_Rxf_2p">Content Object</a></span></p></td><td class="c5"><p class="c0"><span class="c3">Required</span></p></td><td class="c16 c24"><p class="c0"><span class="c3">The video content, such as the URL of the video file, subtitles, and so on.</span></p></td></tr>

<tr class="c10"><td class="c13"><p class="c0"><span class="c3">genres</span></p></td><td class="c8 c14"><p class="c0"><span class="c3">array</span></p></td><td class="c2"><p class="c0"><span class="c3">Required</span></p></td><td class="c16"><p class="c0"><span>A list of strings describing the genre(s) of the movie. Must be one of the values listed in</span><span><a class="c7" href="https://www.google.com/url?q=https://developer.roku.com/docs/specs/direct-publisher-feed-specs/json-dp-spec.md%23genres&amp;sa=D&amp;source=editors&amp;ust=1735580784444002&amp;usg=AOvVaw3uYO4VvX59EJWHs4ZGQx2q">&nbsp;</a></span><span class="c11"><a class="c7" href="https://www.google.com/url?q=https://developer.roku.com/docs/specs/direct-publisher-feed-specs/json-dp-spec.md%23genres&amp;sa=D&amp;source=editors&amp;ust=1735580784444142&amp;usg=AOvVaw3CMOZdpjo9ZbNH7hnJCPfK">genres</a></span><span>.</span></p></td></tr>

<tr class="c15"><td class="c12"><p class="c0"><span class="c3">thumbnail</span></p></td><td class="c8 c24"><p class="c0"><span class="c3">string</span></p></td><td class="c5"><p class="c0"><span class="c3">Required</span></p></td><td class="c16 c24"><p class="c0"><span class="c3">The URL of the thumbnail for the movie. This is used within the channel and in search results. Image dimensions must be at least 800x450 (width x height, 16x9 aspect ratio).</span></p></td></tr>

<tr class="c26"><td class="c13"><p class="c0"><span class="c3">releaseDate</span></p></td><td class="c8 c14"><p class="c0"><span class="c3">string</span></p></td><td class="c2"><p class="c0"><span class="c3">Required</span></p></td><td class="c16"><p class="c0"><span>The date the movie was initially released or first aired. This field is used to sort programs chronologically and group related content in Roku Search. Conforms to the</span><span><a class="c7" href="https://www.google.com/url?q=http://www.iso.org/iso/home/standards/iso8601.htm&amp;sa=D&amp;source=editors&amp;ust=1735580784445589&amp;usg=AOvVaw1V0bnZW4_cmXMabV8C7Ek3">&nbsp;</a></span><span class="c11"><a class="c7" href="https://www.google.com/url?q=http://www.iso.org/iso/home/standards/iso8601.htm&amp;sa=D&amp;source=editors&amp;ust=1735580784445670&amp;usg=AOvVaw2Mgc4KeNal4MBviNX24xxp">ISO 8601</a></span><span>&nbsp;format: {YYYY}-{MM}-{DD}. For example, 2020-11-11</span></p></td></tr>

<tr class="c10"><td class="c12"><p class="c0"><span class="c3">shortDescription</span></p></td><td class="c8 c24"><p class="c0"><span class="c3">string</span></p></td><td class="c5"><p class="c0"><span class="c3">Required</span></p></td><td class="c16 c24"><p class="c0"><span class="c3">A movie description that does not exceed 200 characters. The text will be clipped if longer.</span></p></td></tr>

<tr class="c15"><td class="c13"><p class="c0"><span class="c3">longDescription</span></p></td><td class="c8 c14"><p class="c0"><span class="c3">string</span></p></td><td class="c2"><p class="c0"><span class="c3">Required</span></p></td><td class="c9"><p class="c0"><span class="c3">A longer movie description that does not exceed 500 characters. The text will be clipped if longer. Must be different from shortDescription.</span></p></td></tr>

<tr class="c19"><td class="c12"><p class="c0"><span class="c3">tags</span></p></td><td class="c8 c24"><p class="c0"><span class="c3">array</span></p></td><td class="c5"><p class="c0"><span class="c3">Optional</span></p></td><td class="c16"><p class="c0"><span>A list of one or more tags (for example, &ldquo;dramas&rdquo;, &ldquo;korean&rdquo;, and so on). Each tag is a string and is limited to 20 characters. Tags are used to define what content will be shown within a</span><span><a class="c7" href="https://www.google.com/url?q=https://developer.roku.com/docs/specs/direct-publisher-feed-specs/json-dp-spec.md%23category&amp;sa=D&amp;source=editors&amp;ust=1735580784448365&amp;usg=AOvVaw3nWXUKnZR70fw04eJPMGMF">&nbsp;</a></span><span class="c11"><a class="c7" href="https://www.google.com/url?q=https://developer.roku.com/docs/specs/direct-publisher-feed-specs/json-dp-spec.md%23category&amp;sa=D&amp;source=editors&amp;ust=1735580784448498&amp;usg=AOvVaw3wmN6lI0O7hxFiQQj-vbSd">category</a></span><span>.</span></p></td></tr>

<tr class="c10"><td class="c13"><p class="c0"><span class="c3">credits</span></p></td><td class="c8"><p class="c0"><span class="c11"><a class="c7" href="https://www.google.com/url?q=https://developer.roku.com/docs/specs/direct-publisher-feed-specs/json-dp-spec.md%23credit&amp;sa=D&amp;source=editors&amp;ust=1735580784449050&amp;usg=AOvVaw1V-FwbBFxe56q1IR_y6rOa">Credit Object</a></span></p></td><td class="c2"><p class="c0"><span class="c3">Optional</span></p></td><td class="c9"><p class="c0"><span class="c3">One or more credits. The cast and crew of the movie.</span></p></td></tr>

<tr class="c10"><td class="c12"><p class="c0"><span class="c3">rating</span></p></td><td class="c8"><p class="c0"><span class="c11"><a class="c7" href="https://www.google.com/url?q=https://developer.roku.com/docs/specs/direct-publisher-feed-specs/json-dp-spec.md%23rating&amp;sa=D&amp;source=editors&amp;ust=1735580784449976&amp;usg=AOvVaw0yQd7PF9lbXzEWCf_Kx3GB">Rating Object</a></span></p></td><td class="c5"><p class="c0"><span class="c3">Required</span></p></td><td class="c16 c24"><p class="c0"><span class="c3">A parental rating for the content.</span></p></td></tr>

<tr class="c10"><td class="c13"><p class="c0"><span class="c3">externalIds</span></p></td><td class="c8"><p class="c0"><span class="c11"><a class="c7" href="https://www.google.com/url?q=https://developer.roku.com/docs/specs/direct-publisher-feed-specs/json-dp-spec.md%23externalids&amp;sa=D&amp;source=editors&amp;ust=1735580784451127&amp;usg=AOvVaw1GBWIsevOYPzDqjxWPvo36">External ID Object</a></span></p></td><td class="c2"><p class="c0"><span class="c3">Optional</span></p></td><td class="c9"><p class="c0"><span class="c3">One or more third-party metadata provider IDs.</span></p></td></tr>
</table>

### liveFeed
<table><tr>

<tr>
<td ><p>Field</p></td>
<td ><p>Type</p></td>
<td ><p>Required</p></td>
<td ><p>Description</p></td>
</tr>

<tr>
<td ><p>id</p></td>
<td ><p>string</p></td>
<td ><p>Required</p></td>
<td ><p>An immutable string reference ID for the live feed that does not exceed 50 characters. This should serve as a unique identifier for the live feed across different locales.</p><p>Once created, the ID for the content item may not be changed.</p></td>
</tr>

<tr>
<td ><p>title</p></td>
<td ><p>string</p></td>
<td ><p>Required</p></td>
<td ><p>The title of the live stream in plain text. This field is used for matching in Roku Search. Do not include extra information such as year, version label, and so on.</p></td>
</tr>

<tr>
<td ><p>content</p></td>
<td ><p><a href="https://www.google.com/url?q=https://developer.roku.com/docs/specs/direct-publisher-feed-specs/json-dp-spec.md%23content&amp;sa=D&amp;source=editors&amp;ust=1735596163951143&amp;usg=AOvVaw19hAuv7uy2xPRwy3FUqOGD">Content Object</a></p></td>
<td ><p>Required</p></td>
<td ><p>The actual video content, such as the URL of the live stream.</p></td>
</tr>

<tr>
<td ><p>thumbnail</p></td>
<td ><p>string</p></td>
<td ><p>Required</p></td>
<td ><p>The URL of the primary thumbnail for the live stream. This is used within the channel and in search results. Image dimensions must be at least 800x450 (width x height, 16x9 aspect ratio).</p></td>
</tr>

<tr>
<td ><p>brandedThumbnail</p></td>
<td ><p>string</p></td>
<td ><p>Required</p></td>
<td ><p>The URL of the secondary thumbnail for the live stream. This is used as a backup in the event that the primary image is not suitable. Image dimensions must be at least 800x450 (width x height, 16x9 aspect ratio).</p></td>
</tr>

<tr>
<td ><p>shortDescription</p></td>
<td ><p>string</p></td>
<td ><p>Required</p></td>
<td ><p>A live stream description that does not exceed 200 characters. The text will be clipped if longer.</p></td>
</tr>

<tr>
<td ><p>longDescription</p></td>
<td ><p>string</p></td>
<td ><p>Required</p></td>
<td ><p>A longer live stream description that does not exceed 500 characters. The text will be clipped if longer. Must be different from shortDescription.</p></td>
</tr>

<tr>
<td ><p>tags</p></td>
<td ><p>array</p></td>
<td ><p>Optional</p></td>
<td ><p>A list of one or more tags (for example, &ldquo;dramas&rdquo;, &ldquo;korean&rdquo;, and so on). Each tag is a string and is limited to 20 characters. Tags are used to define what content will be shown within a category and to find content for content curation purposes.</p></td>
</tr>

<tr>
<td ><p>rating</p></td>
<td ><p><a href="https://www.google.com/url?q=https://developer.roku.com/docs/specs/direct-publisher-feed-specs/json-dp-spec.md%23rating&amp;sa=D&amp;source=editors&amp;ust=1735596163957193&amp;usg=AOvVaw3CgljF8XDOjzdPHmfP2HqK">Rating Object</a></p></td>
<td ><p>Required</p></td>
<td ><p>A parental rating for the content.</p></td>
</tr>

<tr>
<td ><p>genres</p></td>
<td ><p>array</p></td>
<td ><p>Optional</p></td>
<td ><p>A list of strings describing the genre(s) of the content. Must be one of the values listed in<a href="https://www.google.com/url?q=https://developer.roku.com/docs/specs/direct-publisher-feed-specs/json-dp-spec.md%23genres&amp;sa=D&amp;source=editors&amp;ust=1735596163958840&amp;usg=AOvVaw3BdpdH6NRqkilIZ37NqCH4">&nbsp;</a><a href="https://www.google.com/url?q=https://developer.roku.com/docs/specs/direct-publisher-feed-specs/json-dp-spec.md%23genres&amp;sa=D&amp;source=editors&amp;ust=1735596163959001&amp;usg=AOvVaw0bq5Noq4qH-ht2YRSZUnrq">Genres</a>.</p></td>
</tr>
</table>

### series
<table><tr>
<td ><p>Field</p></td>
<td ><p>Type</p></td>
<td ><p>Required</p></td>
<td ><p>Description</p></td>
</tr>

<tr>
<td ><p>id</p></td>
<td ><p>string</p></td>
<td ><p>Required</p></td>
<td ><p>An immutable string reference ID for the series that does not exceed 50 characters. This should serve as a unique identifier for the series across different locales.</p><p>Once created, the ID for the content item may not be changed.</p></td>
</tr>

<tr>
<td ><p>title</p></td>
<td ><p>string</p></td>
<td ><p>Required</p></td>
<td ><p>The title of the series in plain text. This field is used for matching in Roku Search. Do not include extra information such as year, version label, and so on.</p></td>
</tr>

<tr>
<td ><p>seasons</p></td>
<td ><p><a href="https://www.google.com/url?q=https://developer.roku.com/docs/specs/direct-publisher-feed-specs/json-dp-spec.md%23season&amp;sa=D&amp;source=editors&amp;ust=1735596441094037&amp;usg=AOvVaw2Ms6q_fwcGrqXXp-4H9Ufp">Season Object</a></p></td>
<td ><p>Required*</p></td>
<td ><p>One or more seasons of the series. Seasons should be used if episodes are grouped by seasons.</p></td>
</tr>

<tr>
<td ><p>episodes</p></td>
<td ><p><a href="https://www.google.com/url?q=https://developer.roku.com/docs/specs/direct-publisher-feed-specs/json-dp-spec.md%23episode&amp;sa=D&amp;source=editors&amp;ust=1735596441095454&amp;usg=AOvVaw2NclnsGHfG9Pb_A_OeMJay">Episode Object</a></p></td>
<td ><p>Required*</p></td>
<td ><p>One or more episodes of the series. Episodes should be used if they are not grouped by seasons (e.g., a mini-series).</p></td>
</tr>

<tr>
<td ><p>genres</p></td>
<td ><p>array</p></td>
<td ><p>Required</p></td>
<td ><p>A list of strings describing the genre(s) of the series. Must be one of the values listed in<a href="https://www.google.com/url?q=https://developer.roku.com/docs/specs/direct-publisher-feed-specs/json-dp-spec.md%23genres&amp;sa=D&amp;source=editors&amp;ust=1735596441097203&amp;usg=AOvVaw2__0fq5cdDSC-cqXXY0_Xr">&nbsp;</a><a href="https://www.google.com/url?q=https://developer.roku.com/docs/specs/direct-publisher-feed-specs/json-dp-spec.md%23genres&amp;sa=D&amp;source=editors&amp;ust=1735596441097453&amp;usg=AOvVaw0dL1haJam_Mptpx24HSLpF">Genres</a>.</p></td>
</tr>

<tr>
<td ><p>thumbnail</p></td>
<td ><p>string</p></td>
<td ><p>Required</p></td>
<td ><p>The URL of the thumbnail for the series. This is used within the channel and in search results. Image dimensions must be at least 800x450 (width x height, 16x9 aspect ratio).</p></td>
</tr>

<tr>
<td ><p>releaseDate</p></td>
<td ><p>string</p></td>
<td ><p>Required</p></td>
<td ><p>The date the series first aired. This field is used to sort programs chronologically and group related content in Roku Search. Conforms to<a href="https://www.google.com/url?q=http://www.iso.org/iso/home/standards/iso8601.htm&amp;sa=D&amp;source=editors&amp;ust=1735596441099782&amp;usg=AOvVaw2IrOJ4jlJ3WU1cgGzW5K97">&nbsp;</a><a href="https://www.google.com/url?q=http://www.iso.org/iso/home/standards/iso8601.htm&amp;sa=D&amp;source=editors&amp;ust=1735596441100035&amp;usg=AOvVaw08zof58CPra-KEtlDYmSjQ">ISO 8601</a>&nbsp;format: {YYYY}-{MM}-{DD}. For example, 2020-11-11</p></td>
</tr>

<tr>
<td ><p>shortDescription</p></td>
<td ><p>string</p></td>
<td ><p>Required</p></td>
<td ><p>A description of the series that does not exceed 200 characters. The text will be clipped if longer.</p></td>
</tr>

<tr>
<td ><p>longDescription</p></td>
<td ><p>string</p></td>
<td ><p>Optional</p></td>
<td ><p>A longer movie description that does not exceed 500 characters. The text will be clipped if longer. Must be different from shortDescription.</p></td>
</tr>

<tr>
<td ><p>tags</p></td>
<td ><p>Array</p></td>
<td ><p>Optional</p></td>
<td ><p>A list of one or more tags (for example, &ldquo;dramas&rdquo;, &ldquo;korean&rdquo;, and so on). Each tag is a string and is limited to 20 characters. Tags are used to define what content will be shown within a<a href="https://www.google.com/url?q=https://developer.roku.com/docs/specs/direct-publisher-feed-specs/json-dp-spec.md%23category&amp;sa=D&amp;source=editors&amp;ust=1735596441103490&amp;usg=AOvVaw2smEle_--ATnrKrOzhj0Qe">&nbsp;</a><a href="https://www.google.com/url?q=https://developer.roku.com/docs/specs/direct-publisher-feed-specs/json-dp-spec.md%23category&amp;sa=D&amp;source=editors&amp;ust=1735596441103745&amp;usg=AOvVaw1vptFiQRQs236L1yON-8sN">category</a>.</p></td>
</tr>

<tr>
<td ><p>credits</p></td>
<td ><p><a href="https://www.google.com/url?q=https://developer.roku.com/docs/specs/direct-publisher-feed-specs/json-dp-spec.md%23credit&amp;sa=D&amp;source=editors&amp;ust=1735596441104499&amp;usg=AOvVaw0rSvHh4FYv1Ubd1RmS8Hvw">Credit Object</a></p></td>
<td ><p>Optional</p></td>
<td ><p>One or more credits. The cast and crew of the series.</p></td>
</tr>

<tr>
<td ><p>externalIds</p></td>
<td ><p><a href="https://www.google.com/url?q=https://developer.roku.com/docs/specs/direct-publisher-feed-specs/json-dp-spec.md%23externalids&amp;sa=D&amp;source=editors&amp;ust=1735596441105666&amp;usg=AOvVaw3VCfQy1FSGKCQt51wzIxIP">External ID Object</a></p></td>
<td ><p>Optional</p></td>
<td ><p>One or more third-party metadata provider IDs.</p></td>
</tr>
</table>

### shortFormVideos
<table><tr>
<td ><p>Field</p></td>
<td ><p>Type</p></td>
<td ><p>Required</p></td>
<td ><p>Description</p></td>
</tr>

<tr>
<td ><p>id</p></td>
<td ><p>string</p></td>
<td ><p>Required</p></td>
<td ><p>An immutable string reference ID for the video that does not exceed 50 characters. This should serve as a unique identifier for the episode across different locales.</p><p>Once created, the ID for the content item may not be changed.</p></td>
</tr>

<tr>
<td ><p>title</p></td>
<td ><p>string</p></td>
<td ><p>Required</p></td>
<td ><p>The title of the video in plain text. This field is used for matching in Roku Search. Do not include extra information such as year, version label, and so on.</p></td>
</tr>

<tr>
<td ><p>content</p></td>
<td ><p><a href="https://www.google.com/url?q=https://developer.roku.com/docs/specs/direct-publisher-feed-specs/json-dp-spec.md%23content&amp;sa=D&amp;source=editors&amp;ust=1735596839046281&amp;usg=AOvVaw3SVTul9bcdeaPyQqw10Lir">Content Object</a></p></td>
<td ><p>Required</p></td>
<td ><p>The video content, such as the URL of the video file, subtitles, and so on.</p></td>
</tr>

<tr>
<td ><p>thumbnail</p></td>
<td ><p>string</p></td>
<td ><p>Required</p></td>
<td ><p>The URL of the thumbnail for the video. This is used within your channel and in search results. Image dimensions must be at least 800x450 (width x height, 16x9 aspect ratio).</p></td>
</tr>

<tr>
<td ><p>shortDescription</p></td>
<td ><p>string</p></td>
<td ><p>Required</p></td>
<td ><p>A description of the video that does not exceed 200 characters. The text will be clipped if longer.</p></td>
</tr>

<tr>
<td ><p>releaseDate</p></td>
<td ><p>string</p></td>
<td ><p>Required</p></td>
<td ><p>The date the video first became available. This field is used to sort programs chronologically and group related content in Roku Search. Conforms to<a href="https://www.google.com/url?q=http://www.iso.org/iso/home/standards/iso8601.htm&amp;sa=D&amp;source=editors&amp;ust=1735596839049553&amp;usg=AOvVaw0FtqiMQZfZJ4umK-tYIAUn">&nbsp;</a><a href="https://www.google.com/url?q=http://www.iso.org/iso/home/standards/iso8601.htm&amp;sa=D&amp;source=editors&amp;ust=1735596839049651&amp;usg=AOvVaw0Ydp_YqpLkQ9RADvcEhA8n">ISO 8601</a>&nbsp;format: {YYYY}-{MM}-{DD}. For example, 2020-11-11</p></td>
</tr>

<tr>
<td ><p>longDescription</p></td>
<td ><p>string</p></td>
<td ><p>Required</p></td>
<td ><p>A longer description that does not exceed 500 characters. The text will be clipped if longer. Must be different from shortDescription.</p></td>
</tr>

<tr>
<td ><p>tags</p></td>
<td ><p>string</p></td>
<td ><p>Optional</p></td>
<td ><p>One or more tags (e.g., &ldquo;dramas&rdquo;, &ldquo;korean&rdquo;, etc). Each tag is a string and is limited to 20 characters. Tags are used to define what content will be shown within a category.</p></td>
</tr>

<tr>
<td ><p>genres</p></td>
<td ><p>array</p></td>
<td ><p>Optional</p></td>
<td ><p>A list of strings describing the genre(s) of the video. Must be one of the values listed in<a href="https://www.google.com/url?q=https://developer.roku.com/docs/specs/direct-publisher-feed-specs/json-dp-spec.md%23genres&amp;sa=D&amp;source=editors&amp;ust=1735596839052523&amp;usg=AOvVaw10LgeQsNGP6XyzC1-OzZEZ">&nbsp;</a><a href="https://www.google.com/url?q=https://developer.roku.com/docs/specs/direct-publisher-feed-specs/json-dp-spec.md%23genres&amp;sa=D&amp;source=editors&amp;ust=1735596839052651&amp;usg=AOvVaw2YhGQRVt0o9U5zVbFHKOYG">genres</a>.</p></td>
</tr>

<tr>
<td ><p>credits</p></td>
<td ><p><a href="https://www.google.com/url?q=https://confluence.portal.roku.com:8443/display/DR/The%2BRoku%2BChannel%2BFeed%2BSpecification%252C%2Bv2.3%23TheRokuChannelFeedSpecification,v2.3-creditProperty&amp;sa=D&amp;source=editors&amp;ust=1735596839053328&amp;usg=AOvVaw3_c38tkJD9oH2gf5da8hmn">Credit Object</a></p></td>
<td ><p>Optional</p></td>
<td ><p>One or more credits. The cast and crew of the video.</p></td>
</tr>

<tr>
<td ><p>rating</p></td>
<td ><p><a href="https://www.google.com/url?q=https://confluence.portal.roku.com:8443/display/DR/The%2BRoku%2BChannel%2BFeed%2BSpecification%252C%2Bv2.3%23TheRokuChannelFeedSpecification,v2.3-ratingProperty&amp;sa=D&amp;source=editors&amp;ust=1735596839054531&amp;usg=AOvVaw1O6-uOVXUUtl4oUZ0Z40kE">Rating Object</a></p></td>
<td ><p>Required</p></td>
<td ><p>A parental rating for the content.</p></td>
</tr>

</table>

### tvSpecials
<table><tr>
<td ><p>Field</p></td>
<td ><p>Type</p></td>
<td ><p>Required</p></td>
<td ><p>Description</p></td>
</tr>

<tr>
<td ><p>id</p></td>
<td ><p>string</p></td>
<td ><p>Required</p></td>
<td ><p>An immutable string reference ID for the TV special that does not exceed 50 characters. This should serve as a unique identifier for the TV special across different locales.</p><p>Once created, the ID for the content item may not be changed.</p></td>
</tr>

<tr>
<td ><p>title</p></td>
<td ><p>string</p></td>
<td ><p>Required</p></td>
<td ><p>The title of the TV special in plain text. This field is used for matching in Roku Search. Do not include extra information such as year, version label, and so on.</p></td>
</tr>

<tr>
<td ><p>content</p></td>
<td ><p><a href="https://www.google.com/url?q=https://developer.roku.com/docs/specs/direct-publisher-feed-specs/json-dp-spec.md%23content&amp;sa=D&amp;source=editors&amp;ust=1735597139039131&amp;usg=AOvVaw0dEXkWd18kn4IW7SUAL4q9">Content Object</a></p></td>
<td ><p>Required</p></td>
<td ><p>The video content, such as the URL of the video file, subtitles, and so on.</p></td>
</tr>

<tr>
<td ><p>thumbnail</p></td>
<td ><p>string</p></td>
<td ><p>Required</p></td>
<td ><p>The URL of the thumbnail for the TV special. This is used within the channel and in search results. Image dimensions must be at least 800x450 (width x height, 16x9 aspect ratio).</p></td>
</tr>

<tr>
<td ><p>genres</p></td>
<td ><p>array</p></td>
<td ><p>Required</p></td>
<td ><p>A list of strings describing the genre(s) of the movie. Must be one of the values listed in<a href="https://www.google.com/url?q=https://developer.roku.com/docs/specs/direct-publisher-feed-specs/json-dp-spec.md%23genres&amp;sa=D&amp;source=editors&amp;ust=1735597139044635&amp;usg=AOvVaw3clz_twjtXb77u8qiCVdfk">&nbsp;</a><a href="https://www.google.com/url?q=https://developer.roku.com/docs/specs/direct-publisher-feed-specs/json-dp-spec.md%23genres&amp;sa=D&amp;source=editors&amp;ust=1735597139045220&amp;usg=AOvVaw1vfcPu5it85kGCJFg0wfXu">Genres</a>.</p></td>
</tr>

<tr>
<td ><p>releaseDate</p></td>
<td ><p>string</p></td>
<td ><p>Required</p></td>
<td ><p>The date the TV special first aired. This field is used to sort programs chronologically and group related content in Roku Search. Conforms to<a href="https://www.google.com/url?q=http://www.iso.org/iso/home/standards/iso8601.htm&amp;sa=D&amp;source=editors&amp;ust=1735597139047954&amp;usg=AOvVaw0Et6EvrCmUATGf1FT62Pzz">&nbsp;</a><a href="https://www.google.com/url?q=http://www.iso.org/iso/home/standards/iso8601.htm&amp;sa=D&amp;source=editors&amp;ust=1735597139048389&amp;usg=AOvVaw1PZgjTN6Wdlgc5h6fovWhY">ISO 8601</a>&nbsp;format: {YYYY}-{MM}-{DD}. For example, 2020-11-11</p></td>
</tr>

<tr>
<td ><p>shortDescription</p></td>
<td ><p>string</p></td>
<td ><p>Required</p></td>
<td ><p>A description of the TV special that does not exceed 200 characters. The text will be clipped if longer.</p></td>
</tr>

<tr>
<td ><p>longDescription</p></td>
<td ><p>string</p></td>
<td ><p>Optional</p></td>
<td ><p>A longer episode description that does not exceed 500 characters. The text will be clipped if longer. Must be different from shortDescription.</p></td>
</tr>

<tr>
<td ><p>credits</p></td>
<td ><p><a href="https://www.google.com/url?q=https://developer.roku.com/docs/specs/direct-publisher-feed-specs/json-dp-spec.md%23credit&amp;sa=D&amp;source=editors&amp;ust=1735597139054318&amp;usg=AOvVaw06qHaZPAO1Ca1fePnBIum-">Credit Object</a></p></td>
<td ><p>Optional</p></td>
<td ><p>One or more credits. The cast and crew of the TV special.</p></td>
</tr>

<tr>
<td ><p>rating</p></td>
<td ><p><a href="https://www.google.com/url?q=https://developer.roku.com/docs/specs/direct-publisher-feed-specs/json-dp-spec.md%23rating&amp;sa=D&amp;source=editors&amp;ust=1735597139057193&amp;usg=AOvVaw1kFfcGVHECxnWJtHcHHEaL">Rating Object</a></p></td>
<td ><p>Required</p></td>
<td ><p>A parental rating for the content.</p></td>
</tr>

<tr>
<td ><p>tags</p></td>
<td ><p>Array</p></td>
<td ><p>Optional</p></td>
<td ><p>A list of one or more tags (e.g., &ldquo;dramas&rdquo;, &ldquo;korean&rdquo;, etc). Each tag is a string and is limited to 20 characters. Tags are used to define what content will be shown within a<a href="https://www.google.com/url?q=https://developer.roku.com/docs/specs/direct-publisher-feed-specs/json-dp-spec.md%23category&amp;sa=D&amp;source=editors&amp;ust=1735597139061070&amp;usg=AOvVaw23SCfHvfmukTkgCQpRtlgM">&nbsp;</a><a href="https://www.google.com/url?q=https://developer.roku.com/docs/specs/direct-publisher-feed-specs/json-dp-spec.md%23category&amp;sa=D&amp;source=editors&amp;ust=1735597139061578&amp;usg=AOvVaw1risaJdymLixx9xEDQeaO0">category</a>.</p></td>
</tr>

<tr>
<td ><p>externalIds</p></td>
<td ><p><a href="https://www.google.com/url?q=https://developer.roku.com/docs/specs/direct-publisher-feed-specs/json-dp-spec.md%23externalids&amp;sa=D&amp;source=editors&amp;ust=1735597139063104&amp;usg=AOvVaw38Q1QKmEUiagiCClzmHwBR">External ID Object</a></p></td>
<td ><p>Optional</p></td>
<td ><p>One or more third-party metadata provider IDs.</p></td>
</tr>

</table>

### categories
<table><tr>
<td ><p>Field</p></td>
<td ><p>Type</p></td>
<td ><p>Required</p></td>
<td ><p>Description</p></td>
</tr>

<tr>
<td ><p>name</p></td>
<td ><p>string</p></td>
<td ><p>Required</p></td>
<td ><p>The name of the category that will show up in the channel.</p></td>
</tr>

<tr>
<td ><p>playlistName</p></td>
<td ><p>string</p></td>
<td ><p>Required*</p></td>
<td ><p>The name of the playlist in this feed that contains the content for this category.</p></td>
</tr>

<tr>
<td ><p>query</p></td>
<td ><p>string</p></td>
<td ><p>Required*</p></td>
<td ><p>The query that will specify the content for this category. It is a Boolean expression containing tags that you have provided in your content feed. The available operators are:AND</p><p>OR</p><p>You cannot use both operators in the same query; however, you can use more than one in a single query. For example, if your feed has the tags &quot;romance&quot;, &quot;movie&quot;, &quot;korean&quot; and &quot;dramas&quot;, you could do:movie AND korean</p><p>movie AND korean AND dramas</p><p>romance OR dramas</p><p>The following is NOT supported:movie AND romance OR dramas</p></td>
</tr>

<tr>
<td ><p>order</p></td>
<td ><p>enum</p></td>
<td ><p>Required</p></td>
<td ><p>The order of the category. Must be one of the following:manual: For playlists only</p><p>most_recent: reverse chronological order</p><p>chronological: the order in which the content was published (e.g., Episode 1, Episode 2, etc.)</p><p>most_popular: sort by popularity (based on Roku usage data).</p></td>
</tr>

</table>

### playlists
<table><tr>
<td ><p>Field</p></td>
<td ><p>Type</p></td>
<td ><p>Required</p></td>
<td ><p>Description</p></td>
</tr>

<tr>
<td ><p>name</p></td>
<td ><p>string</p></td>
<td ><p>Required</p></td>
<td ><p>The name of the playlist. The name is limited to 20 characters.</p></td>
</tr>

<tr>
<td ><p>itemIds</p></td>
<td ><p>string</p></td>
<td ><p>Required</p></td>
<td ><p>An ordered list of one or more item IDs. An item ID is the ID of a movie/series/short-form video/TV special</p></td>
</tr>

</table>

<hr />

### content

<table>
<tr>
<td><p>Field</p></td>
<td><p>Type</p></td>
<td><p>Required</p></td>
<td><p>Description</p></td>
</tr>

<tr>
<td><p>dateAdded</p></td>
<td><p>string</p></td>
<td><p>Required</p></td>
<td><p>The date the video was added to the library in the<a href="https://www.google.com/url?q=http://www.iso.org/iso/home/standards/iso8601.htm&amp;sa=D&amp;source=editors&amp;ust=1735592446234332&amp;usg=AOvVaw3iQIGOd3r2ahH2FSc5rP5-">&nbsp;</a><a href="https://www.google.com/url?q=http://www.iso.org/iso/home/standards/iso8601.htm&amp;sa=D&amp;source=editors&amp;ust=1735592446234416&amp;usg=AOvVaw3aVZ1fU_bhVqo1DYEVgp-P">ISO 8601</a>&nbsp;format: {YYYY}-{MM}-{DD}T{hh}:{mm}:{ss}+{TZ}. For example, 2020-11-11T22:21:37+00:00.</p><p></p><p>This information is used to generate the &ldquo;Recently Added&rdquo; category.</p></td>
</tr>

<tr>
<td><p>videos</p></td>
<td><p><a href="https://www.google.com/url?q=https://developer.roku.com/docs/specs/direct-publisher-feed-specs/json-dp-spec.md%23video&amp;sa=D&amp;source=editors&amp;ust=1735592446235008&amp;usg=AOvVaw0WY4jHnA1I2NVvsVaK3Vzp">Video Object</a></p></td>
<td><p>Required</p></td>
<td><p>One or more video files. For non-adaptive streams, the same video may be specified with different qualities so the Roku player can choose the best one based on bandwidth.</p></td>
</tr>

<tr>
<td><p>duration</p></td>
<td><p>integer</p></td>
<td><p>Required</p></td>
<td><p>Runtime in seconds.</p></td>
</tr>

<tr>
<td><p>captions</p></td>
<td><p><a href="https://www.google.com/url?q=https://developer.roku.com/docs/specs/direct-publisher-feed-specs/json-dp-spec.md%23caption&amp;sa=D&amp;source=editors&amp;ust=1735592446236547&amp;usg=AOvVaw1cIHNchwsSN7Jsze7ZiJIP">Caption Object</a></p></td>
<td><p>Required for live broadcast replays</p></td>
<td><p>Supported formats are described in<a href="https://www.google.com/url?q=https://developer.roku.com/docs/developer-program/media-playback/closed-caption.md&amp;sa=D&amp;source=editors&amp;ust=1735592446237018&amp;usg=AOvVaw3U0vEq71hRsALV-jveTB0Y">&nbsp;</a><a href="https://www.google.com/url?q=https://developer.roku.com/docs/developer-program/media-playback/closed-caption.md&amp;sa=D&amp;source=editors&amp;ust=1735592446237095&amp;usg=AOvVaw09N4Fqi4ZiQ9e42AlPY5WK">Closed Caption Support</a>.</p></td>
</tr>

<tr>
<td><p>trickPlayFiles</p></td>
<td><p><a href="https://www.google.com/url?q=https://developer.roku.com/docs/specs/direct-publisher-feed-specs/json-dp-spec.md%23trickplayfile&amp;sa=D&amp;source=editors&amp;ust=1735592446237526&amp;usg=AOvVaw1Jt1i-1OTcn-VZAxgGL9lP">Trickplay File Object</a></p></td>
<td><p>Optional</p></td>
<td><p>The trickplay file(s) that displays images as a user scrubs through a video, in Roku&rsquo;s BIF format. Trickplay files in multiple qualities can be provided.</p></td>
</tr>

<tr>
<td><p>language</p></td>
<td><p>string</p></td>
<td><p>Required</p></td>
<td><p>The language in which the video was originally produced (e.g., &ldquo;en&rdquo;, &ldquo;en-US&rdquo;, &ldquo;es&rdquo;, etc). ISO 639 alpha-2 or alpha-3 language code string.</p></td>
</tr>

<tr>
<td><p>validityPeriodStart</p></td>
<td><p>string</p></td>
<td><p>Optional</p></td>
<td><p>The date when the content should become available in<a href="https://www.google.com/url?q=http://www.iso.org/iso/home/standards/iso8601.htm&amp;sa=D&amp;source=editors&amp;ust=1735592446239085&amp;usg=AOvVaw3jkBKQAspdAkDA3bt8oFOi">&nbsp;</a><a href="https://www.google.com/url?q=http://www.iso.org/iso/home/standards/iso8601.htm&amp;sa=D&amp;source=editors&amp;ust=1735592446239146&amp;usg=AOvVaw3KKGgWbwqI_OI-yvyBiZwT">ISO 8601</a>format: {YYYY}-{MM}-{DD}T{hh}:{mm}:{ss}+{TZ}. For example, 2020-11-11T22:21:37+00:00</p></td>
</tr>

<tr>
<td><p>validityPeriodEnd</p></td>
<td><p>string</p></td>
<td><p>Optional</p></td>
<td><p>The date when the content is no longer available in<a href="https://www.google.com/url?q=http://www.iso.org/iso/home/standards/iso8601.htm&amp;sa=D&amp;source=editors&amp;ust=1735592446239796&amp;usg=AOvVaw3pHONb0_yoJj6rGbgQ2O5Z">&nbsp;</a><a href="https://www.google.com/url?q=http://www.iso.org/iso/home/standards/iso8601.htm&amp;sa=D&amp;source=editors&amp;ust=1735592446239850&amp;usg=AOvVaw2aWZ8GV8I_bHQ_t4Gql-Q2">ISO 8601</a>format: {YYYY}-{MM}-{DD}T{hh}:{mm}:{ss}+{TZ}. For example, 2020-11-11T22:21:37+00:00</p></td>
</tr>

<tr>
<td><p>adBreaks</p></td>
<td><p>string</p></td>
<td><p>Required if monetizing content</p></td>
<td><p>One or more time codes. Represents a time duration from the beginning of the video where an ad shows up. Conforms to the format: {hh}:{mm}:{ss} and in the form of an SCTE-35 marker. See each content type for its ad policy.</p></td>
</tr>
</table>

### video
<table><tr>
<td ><p>Field</p></td>
<td ><p>Type</p></td>
<td ><p>Required</p></td>
<td ><p>Description</p></td>
</tr>

<tr>
<td ><p>url</p></td>
<td ><p>string</p></td>
<td ><p>Required</p></td>
<td ><p>The URL of the video itself. The URL must use the secure protocol prefix &quot;https://&quot;.</p><p></p><p>All videos must play across multiple devices.</p><p></p><p>The video should be served from a CDN (Content Distribution Network).</p><p></p><p>Supported formats are described in<a href="https://www.google.com/url?q=https://developer.roku.com/docs/specs/media/streaming-specifications.md&amp;sa=D&amp;source=editors&amp;ust=1735595249120379&amp;usg=AOvVaw2hctLjn8oRt4G0ZiuuGhQ6">&nbsp;</a><a href="https://www.google.com/url?q=https://developer.roku.com/docs/specs/media/streaming-specifications.md&amp;sa=D&amp;source=editors&amp;ust=1735595249120553&amp;usg=AOvVaw1Z1UQYm2bzyCXSSwzl987e">Audio and Video Support</a>.</p></td>
</tr>

<tr>
<td ><p>quality</p></td>
<td ><p>enum</p></td>
<td ><p>Required</p></td>
<td ><p>Must be one of the following display types:SD: Anything under 720p</p><p>HD: 720p</p><p>FHD: 1080p</p><p>UHD: 4K</p><p>If your stream uses an adaptive bitrate, set the quality to the highest available one. Provide at least six profiles of video quality with the bitrate ranging from 192 to at least 4000. Roku needs the low end to support mobile/web playback and also recommends the high end in the 5000 range to support 4k TVs. The ideal bitrate ladder is included below, along with resolutions:ResolutionBitrate (video + audio)1920X1080 5800 1920X1080 4300 1280X720 3500 1280X720 2750 720X404 1750 720X404 1100 512X288 700 384X216 400 384X216 192</p></td>
</tr>

<tr>
<td ><p>videoType</p></td>
<td ><p>enum</p></td>
<td ><p>Required</p></td>
<td ><p>Must be one of the following:HLS</p><p>SMOOTH</p><p>DASH</p><p>MP4</p><p>MOV</p><p>M4V</p><p></p><p>Provided videos must be unencrypted because there is no encryption support:</p><p>Audio should be as follows:Minimum: first track of Stereo</p><p>Preferred: second track of Dolby (optional)</p></td>
</tr>
</table>

## captions
<table><tr>
<td ><p>Field</p></td>
<td ><p>Type</p></td>
<td ><p>Required</p></td>
<td ><p>Description</p></td>
</tr>

<tr>
<td ><p>url</p></td>
<td ><p>string</p></td>
<td ><p>Required</p></td>
<td ><p>The URL of the video caption file. The URL must use the secure protocol prefix &quot;https://&quot;.</p><p>Supported formats are described in <a href="https://www.google.com/url?q=https://developer.roku.com/docs/developer-program/media-playback/closed-caption.md&amp;sa=D&amp;source=editors&amp;ust=1735598246838427&amp;usg=AOvVaw1DC5bqHzdKll85aMuhSkkf">Closed Caption Support</a>.</p></td>
</tr>

<tr>
<td ><p>language</p></td>
<td ><p>string</p></td>
<td ><p>Required</p></td>
<td ><p>A language code for the subtitle (e.g., &ldquo;en&rdquo;, &ldquo;es-mx&rdquo;, &ldquo;fr&rdquo;, etc). <a href="https://www.google.com/url?q=https://www.loc.gov/standards/iso639-2/php/code_list.php&amp;sa=D&amp;source=editors&amp;ust=1735598246839066&amp;usg=AOvVaw25n52Y9LZZdCSKzKQVdxQY">ISO 639-2 or alpha-3</a>&nbsp;language code string.</p></td>
</tr>

<tr>
<td ><p>captionType</p></td>
<td ><p>enum</p></td>
<td ><p>Required</p></td>
<td ><p>The type of caption. Default is SUBTITLE. Must be one of the following:</p><ul class="c19 lst-kix_8gwbacywlvhx-0 start"><li class="c13 li-bullet-0">CLOSED_CAPTION</li><li class="c13 li-bullet-0">SUBTITLE</li></ul></td>
</tr>
</table>

### trickPlayFiles
<table><tr>
<td ><p>Field</p></td>
<td ><p>Type</p></td>
<td ><p>Required</p></td>
<td ><p>Description</p></td>
</tr>

<tr>
<td ><p>url</p></td>
<td ><p>string</p></td>
<td ><p>Required</p></td>
<td ><p>The URL to the image representing the trickplay file. The URL must use the secure protocol prefix &quot;https://&quot;.</p></td>
</tr>

<tr>
<td ><p>quality</p></td>
<td ><p>enum</p></td>
<td ><p>Required</p></td>
<td ><p>Must be one of the following:</p><ul class="c14 lst-kix_hsk1wvxdvn3t-0 start"><li class="c3 li-bullet-0">HD &ndash; 720p</li><li class="c3 li-bullet-0">FHD &ndash; 1080p</li></ul></td>
</tr>
</table>

<hr />

### credits
<table><tr>
<td ><p>Field</p></td>
<td ><p>Type</p></td>
<td ><p>Required</p></td>
<td ><p>Description</p></td>
</tr>

<tr>
<td ><p>name</p></td>
<td ><p>string</p></td>
<td ><p>required</p></td>
<td ><p>name of the person</p></td>
</tr>

<tr>
<td ><p>role</p></td>
<td ><p>enum</p></td>
<td ><p>required</p></td>
<td ><p>The role of the person, which must be one of the following values:</p><ul class="c15 lst-kix_mqj03whkvfzm-0 start"><li class="c7 li-bullet-0">actor</li><li class="c7 li-bullet-0">anchor</li><li class="c7 li-bullet-0">host</li><li class="c7 li-bullet-0">narrator</li><li class="c7 li-bullet-0">voice</li><li class="c7 li-bullet-0">director</li><li class="c7 li-bullet-0">producer</li><li class="c7 li-bullet-0">screenwriter</li></ul></td>
</tr>

<tr>
<td ><p>birthDate</p></td>
<td ><p>string</p></td>
<td ><p>required</p></td>
<td ><p>birthdate of the person</p></td>
</tr>
</table>

### rating
<table><tr>
<td ><p>Field</p></td>
<td ><p>Type</p></td>
<td ><p>Required</p></td>
<td ><p>Description</p></td>
</tr>

<tr>
<td ><p>rating</p></td>
<td ><p>enum</p></td>
<td ><p>Required</p></td>
<td ><p>Must be a value listed in <a href="https://www.google.com/url?q=https://developer.roku.com/docs/specs/direct-publisher-feed-specs/json-dp-spec.md%23parental-ratings&amp;sa=D&amp;source=editors&amp;ust=1735609196822416&amp;usg=AOvVaw08cP87D77gHEm4rv3whRH9">Parental ratings</a></p><p>Do not include any content targeted specifically to children.</p><p></p><p>If you specify UNRATED, you do not need to provide the &quot;ratingSource&quot; field.</p></td>
</tr>

<tr>
<td ><p>ratingSource</p></td>
<td ><p>enum</p></td>
<td ><p>Required</p></td>
<td ><p>Must be one of the following:</p><ul class="c16 lst-kix_ww9l91nj0ybo-0 start"><li class="c7 li-bullet-0">BBFC</li><li class="c7 li-bullet-0">CHVRS</li><li class="c7 li-bullet-0">CLASSIND</li><li class="c7 li-bullet-0">CPR</li><li class="c7 li-bullet-0">FSF</li><li class="c7 li-bullet-0">FSK</li><li class="c7 li-bullet-0">MPAA</li><li class="c7 li-bullet-0">UK_CP</li><li class="c7 li-bullet-0">USA_PR</li></ul><p>See <a href="https://www.google.com/url?q=https://developer.roku.com/docs/specs/direct-publisher-feed-specs/json-dp-spec.md%23rating-sources&amp;sa=D&amp;source=editors&amp;ust=1735609196824736&amp;usg=AOvVaw1UNxsu0JIyZoPL0RWaBJ3V">Rating sources</a>&nbsp;for more information.</p></td>
</tr>

</table>


### externalIds
<table><tr>
<td ><p>Field</p></td>
<td ><p>Type</p></td>
<td ><p>Required</p></td>
<td ><p>Description</p></td>
</tr>

<tr>
<td ><p>id</p></td>
<td ><p>string</p></td>
<td ><p>Required</p></td>
<td ><p>The third-party metadata provider ID for the video content.</p><p></p><p>If IMDB was being used for example, the last part of the URL of a movie would be used such as &quot;<a href="https://www.google.com/url?q=http://www.imdb.com/title/tt0371724%2522&amp;sa=D&amp;source=editors&amp;ust=1735609380959327&amp;usg=AOvVaw37Cc0uRvpgegv3C0s1gp4e">http://www.imdb.com/title/tt0371724&quot;</a>.</p></td>
</tr>

<tr>
<td ><p>idType</p></td>
<td ><p>enum</p></td>
<td ><p>Required</p></td>
<td ><p>Must be one of the following:</p><ul class="c18 lst-kix_hqqnq0g9d90a-0 start"><li class="c13 li-bullet-0">TMS &ndash; A Tribune Metadata Service ID for the content</li><li class="c13 li-bullet-0">ROVI - A Rovi ID for the content</li><li class="c13 li-bullet-0">IMDB &ndash; An Internet Movie Database ID</li><li class="c13 li-bullet-0">EIDR &ndash; An Entertainment Identifier Registry ID</li></ul></td>
</tr>

</table>


