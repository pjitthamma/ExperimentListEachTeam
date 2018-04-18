select case when left(e.experiment_name, 3) = 'lot' then 'MMB'
 when left(E.experiment_name, 3) = 'at-' then 'FE Engineering'
 when left(e.experiment_name, 3) = 'bud' then 'MMB'
 when left(e.experiment_name, 4) = 'PETE' then 'FE Engineering'
 when left(e.experiment_name, 4) = 'PER-' then 'Performance'
 else t.team_name end as team_name, t.team_id, e.experiment_name, er.experiment_id, er.experiment_run_id, substring(e.[description],0,50) as description, er.startdate,
 year(startdate) start_year, month(startdate) as start_month
 FROM agoda_core.dbo.experiments AS e
 INNER JOIN    agoda_core.dbo.experiment_runs AS er
 ON e.experiment_id = er.experiment_id
 LEFT OUTER JOIN  agoda_core.[dbo].[experiment_team] AS t
 ON e.team_id = t.team_id
 where er.rec_status = 1
 AND er.panic_stop = 0
 AND er.enddate > GETDATE()
 and er.integration_variant is not null
 and er.[all_clusters_flag] = 1
 and t.team_id is not null
 and e.[description] not like '%kill switch%' and e.[description] not like '%kill-switch%'
 and e.[description] not like '%KILLSWITCH%' and e.[description] not like '%KILL-SWITCH%'
 and experiment_name not like 'NHAM-%' and experiment_name not like '%KILLSWITCH%' and experiment_name not like '%KILL-SWITCH%'
 and experiment_name not like '%kill switch%' and experiment_name not like '%kill-switch%'
 and experiment_name not like '%SWITCH%' and experiment_name not like '%KILL%' and experiment_name not like '%-B%'
 and 
 ((e.team_id in ( select team_id from agoda_core.[dbo].[experiment_team] where team_name like 'Apps%') and er.startdate < GETDATE() - 30)
 or
 (e.team_id not in ( select team_id from agoda_core.[dbo].[experiment_team] where team_name like 'Apps%') and er.startdate < GETDATE() - 14)
 )
 and experiment_name not in ('FACEBOOK-DESKTOP','PER-3251-KILLSWITCH','TOP-CITY-LINK','REDIRECT-RULE-MASTER',
'MMB-820-KEEPCOOKIE','LOGIN-3039-CKLOST','MMB-820-HASHCOOKIE','CW-69','EXP-CTRL-1','EXP-CTRL-2','CDCD-24',
'MISC-1','MMB-820-RURL','MMB-820-OLDLOGIN', 'LOGIN-2630-CKLOST', 'LOGIN-CUSCO-1449','LOGIN-HEIMDALL',
'FACEBOOK-MOBILE','LOGIN-CAPTCHA','MMB-326','CDCD-18','REDIRECT-BLT-TEM','LOGIN-V2','MMB-623','RED-RULE-MSG-DATA',
'HALO-6501-KILLSWITCH','RED-PROMOINBOXICON','LOGIN-CUSCO-1449','MMB-654','PRIUS-2557-KS','HALO-6318-KILLSWITCH',
'MMB-818','MMB-812','BOOKONREQUEST-SWITCH','RED-PROMOZONE-MASTER','HALO-6275-KILLSWITCH','FAM-366-SWITCH','MMB-877',
'CDCD-25-KILLSWITCH','FAM-657-SWITCH','SWAT-DPGG-SIGNIN','SWAT-DPGG','MMB-820-KEEPCOOKIE','IKKI-5863-SWITCH',
'HALO-6317-KILLSWITCH','MMB-820-HASHCOOKIE','MMB-1144','AG-4712-SWITCH','MMB-488','PRIUS-2557-KS','NEWGEO-MOBILE-3',
'NHAM-676','HALO-7211-KILLSWITCH','DPGG-HOME','AT-352','FEDATA-1-SWITCH','IKKI-5966-SWITCH','LOGIN-1381-FIXBIAS',
'LOGIN-2293-FIXBIAS','PRIUS-2427-SWITCH','MIN-7802-TRACKING','PFE-942-SWITCH','IKKI-5111-SWITCH','MIN-8450-KILLSWITCH',
'PPC-9917','PER-3251-CONVERT','CW-WECHAT-LOGIN','LOGIN-MMB-FBPANEL','MMB-820-LOG','CAPTCHA-MOBILE','MB-820-NEW',
'LOGIN-3217-URL','REVIEW-EXP-CTRL','BAY-3524-B','BAY-3807','BAY-3598','BAY-3691-B','PREREN-1','BAY-2109-B','BAY-3523-B',
'BAY-3515','BAY-2713-3','BAY-2174','BAY-3409','NEWGEO-MOBILE-3','BAY-2201','META-AB','MMB-1032','FEDATA-1-SWITCH',
'FEDATA-1-DEV','FEDATA-1-PROD','FEDATA-389','FEDATA-390','MIN-9553-KILLSWITCH','IKKI-6030-SWITCH','FAM-1072-SWITCH',
'MIN-9557-TRACKING','PER-3976','IKKI-5545-SWITCH','MMB-980','MMB-1567','PER-3572-KILLSWITCH','DPGG-SEARCH','PER-3826',
'FEDATA-267','FEDATA-200','CCI-1045-C3','BAY-MOB-REVIEW-KILL','IKKI-6121-SWITCH','AT-337')
 order by startdate;