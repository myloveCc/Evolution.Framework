﻿/*******************************************************************************
 * Copyright © 2016 NFine.Framework 版权所有
 * Author: NFine
 * Description: NFine快速开发平台
 * Website：http://www.nfine.cn
*********************************************************************************/
using Evolution.Repository;
using Evolution.Data;
using Evolution.Domain.Entity.SystemManage;
using Evolution.Domain.IRepository.SystemManage;

namespace Evolution.Repository.SystemManage
{
    public class ModuleRepository : RepositoryBase<ModuleEntity>, IModuleRepository
    {
        public ModuleRepository(NFineDbContext ctx) : base(ctx)
        {

        }
    }
}