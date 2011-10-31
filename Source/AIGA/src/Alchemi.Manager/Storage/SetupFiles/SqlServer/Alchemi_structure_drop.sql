
/****** Object:  Table [dbo].[application]    Script Date: 12/10/2005 6:01:22 PM ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[application]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[application];

/****** Object:  Table [dbo].[executor]    Script Date: 12/10/2005 6:01:22 PM ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[executor]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[executor];

/****** Object:  Table [dbo].[grp]    Script Date: 12/10/2005 6:01:22 PM ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[grp]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[grp];

/****** Object:  Table [dbo].[grp_prm]    Script Date: 12/10/2005 6:01:22 PM ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[grp_prm]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[grp_prm];

/****** Object:  Table [dbo].[prm]    Script Date: 12/10/2005 6:01:22 PM ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[prm]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[prm];

/****** Object:  Table [dbo].[thread]    Script Date: 12/10/2005 6:01:22 PM ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[thread]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[thread];

/****** Object:  Table [dbo].[usr]    Script Date: 12/10/2005 6:01:22 PM ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usr]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[usr];
