



15338

select * from taggings where tag_id = 15338
select * from metadata_items item
inner join taggings t on items.id = t.metadata_item_id 
where item.title like '%ad%'
select * from taggings inner join tags on taggings.tag_id = tags.id where taggings.metadata_item_id= 155274
select * from metadata_items where id =155432

insert into tags (tag, tag_type) values ('asdf', 4)
insert into taggings (metadata_item_id, tag_id) values(8051, 1)

update tags set created_at = '1/23/2015 10:40 PM' where id=15345

update tags set created_at = '1/23/2015 10:40 PM' where id=15345

delete from tags where id=15345



update tags set tag='test2' where id=15346
select * from tags where id=15345



select * from taggings where metadata_item_id = 8051

select * from taggings where tag_id = 15345






select taggings.* from taggings 
inner join tags on taggings.tag_id = tags.id 
where taggings.metadata_item_id= 8051
and tag_type = 4



insert into taggings (metadata_item_id, tag_id)
select taggings.* from taggings 
inner join tags on taggings.tag_id = tags.id 
where taggings.metadata_item_id= 8051
and tag_type = 4



select item.id as itemid, item.title, t.id as tagid from metadata_items item
left outer join taggings t on item.id = t.metadata_item_id 
where item.title like '%rbd%'


select tags.id, tags.tag, item.id as itemid, item.title, t.id as tagid, item.user_thumb_url, item.user_art_url from 
metadata_items item
left outer join taggings t on item.id = t.metadata_item_id 
left outer join tags on tags.id = t.tag_id
where item.title like '%scop%'

select item.id as itemid, item.title, item.user_thumb_url from 
metadata_items item
where item.title like '%scop%'

select item.id as itemid, item.title, item.user_thumb_url, item.user_art_url from 
metadata_items item
where item.title like 'fset%'

where item.title like '%scop%'
user_art_url
media://1/24c6806b252492759ec5ec83cc5461a739ab615.bundle/Contents/Thumbnails/thumb1.jpg
media://4/5eb6ab4be715b26546aab6d312a02ef31e8895f.bundle/Contents/Art/art1.jpg
SELECT * FROM metadata_items ORDER BY ROWID ASC LIMIT 1

select tags.id, tags.tag, item.id as itemid, item.title, t.id as tagid, item.id as metadataid from 
metadata_items item
left outer join taggings t on item.id = t.metadata_item_id 
left outer join tags on tags.id = t.tag_id
order by item.created_at desc
LIMIT 200

select part.file from 
media_items mi 
inner join media_parts part on part.media_item_id = mi.id
where mi.metadata_item_id = 155274

local://6481	metadata://posters/com.plexapp.agents.localmedia_59733d18191a7b6f86139decda1d5136d65d0a67
media://1/24c6806b252492759ec5ec83cc5461a739ab615.bundle/Contents/Thumbnails/thumb1.jpg

select * from 
metadata_items where id = 6481

select part.file, item.id as metadataid from 
media_items mi 
inner join media_parts part on part.media_item_id = mi.id
inner join metadata_items item on mi.metadata_item_id = item.id
where part.file like '%Cristal Caitlin%'

select * from media_parts part where part.file like '%Bailey%'

p:\mp4\Staci Carr\Hardcore Heaven 3 XXX DVDRip x264-CiCXXX\Hardcore.Heaven.3.XXX.DVDRip.x264-CiCXXX.mp4	155490

select * from taggings 
where tag_id = 31034

select * from taggings 
inner join metadata_items item on taggings.metadata_item_id = item.id
where tag_id = 31034

	SELECT  directories.*
	FROM
		media_items
		INNER JOIN metadata_items             on metadata_items.id         = media_items.metadata_item_id
		INNER JOIN media_parts                on media_parts.media_item_id = media_items.id
		INNER JOIN library_sections           on library_sections.id       = media_items.library_section_id
		INNER JOIN directories                on directories.id            = media_parts.directory_id
where metadata_items.id = 6481

	SELECT  metadata_items.title, metadata_items.metadataid, directories.path
	FROM
		media_items
		INNER JOIN metadata_items             on metadata_items.id         = media_items.metadata_item_id
		INNER JOIN media_parts                on media_parts.media_item_id = media_items.id
		INNER JOIN library_sections           on library_sections.id       = media_items.library_section_id
		INNER JOIN directories                on directories.id            = media_parts.directory_id
where metadata_items.id = 163990
    

1	24521
2	22148
3	22148
4	15029
5	16611
6	16611
7	15820
8	21357
9	15820
10	15820
11	17402
12	17402
1	3813
2	7627

"insert into taggings(metadata_item_id, tag_id) values(155306, 31033)"

select * from taggings
where tag_id = 31033

select * from

delete from taggings
where tag_id = 31036
31038


select item.id as itemid, item.title, item.user_thumb_url, item.user_art_url from 
metadata_items item
where item.title like 'venu%' 
or item.title like 'adn%'
or item.title like 'atkd%'
or item.title like 'bbi%'
or item.title like 'bf%'
or item.title like 'dvdes%'
or item.title like 'fajs%'
item.title like 'wanz%' 
or item.title like 'vrtm%'
or item.title like 'wnz%'
or item.title like 'dasd%'
or item.title like 'ezd%'
or item.title like 'gvg%'
or item.title like 'havd%'
or item.title like 'hbad%'
or item.title like 'hodv%'
or item.title like 'hunt%'
or item.title like 'hunta%'
or item.title like 'idbd%'
or item.title like 'iesp%'
or item.title like 'iptd%'
or item.title like 'ipz%'
or item.title like 'juc%'
or item.title like 'jufd%'

where item.title like 'mxsp%' 
or item.title like 'mkck%'
or item.title like 'mkmp%'
or item.title like 'natr%'
or item.title like 'nhdta%'
or item.title like 'htms%'
or item.title like 'jux%'
or item.title like 'kncs%'
or item.title like 'mcsr%'
or item.title like 'mdb%'
or item.title like 'mdyd%'
or item.title like 'meyd%'
or item.title like 'mibd%'
or item.title like 'midd%'
or item.title like 'migd%'
or item.title like 'mild%'

or item.title like 'pgd%'
or item.title like 'pppd%'
or item.title like 'rabs%'
or item.title like 'scop%'
or item.title like 'kncs%'
or item.title like 'mcsr%'
or item.title like 'mdb%'
or item.title like 'mdyd%'
or item.title like 'meyd%'
or item.title like 'mibd%'
or item.title like 'midd%'
or item.title like 'migd%'
or item.title like 'mild%'




select item.id as itemid, item.title, item.user_thumb_url, item.user_art_url from 
metadata_items item
where item.title like 'umd%'
or item.title like 'vandr%'
or item.title like 'vdd%'
or item.title like 'abs%'
or item.title like 'adz%'
or item.title like 'ap%'
or item.title like 'atid%'
or item.title like 'bdsr%'


select item.id as itemid, item.title, item.user_thumb_url, item.user_art_url from 
metadata_items item
where item.title like 'tamo%'
or item.title like 'sbci%'
order by item.created_at desc
LIMIT 200

or item.title like 'rdd%'
or item.title like 'oyc%'
or item.title like 'oomn%'
or item.title like 'ovg%'
or item.title like 'ofje%'
or item.title like 'okad%'
or item.title like 'oned%'
or item.title like 'nitr%'
or item.title like 'mxsp%'
or item.title like 'mvsd%'
or item.title like 'mmnd%'
or item.title like 'nass%'
or item.title like 'nsps%'

select item.id as itemid, item.title, item.id as metadataid from 
metadata_items item
order by item.created_at desc
LIMIT 200



select item.id as itemid, item.title, item.user_thumb_url, item.user_art_url from 
metadata_items item
order by item.created_at desc
LIMIT 200

pgd
kisd
idbd


select tags.id, tags.tag, item.id as itemid, item.title, t.id as tagid, item.id as metadataid from
metadata_items item
left outer join taggings t on item.id = t.metadata_item_id
left outer join tags on tags.id = t.tag_id
where item.title like 'havd%'