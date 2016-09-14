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
using Evolution.Repository.SystemManage;
using System.Collections.Generic;

namespace Evolution.Repository.SystemManage
{
    public class RoleRepository : RepositoryBase<RoleEntity>, IRoleRepository
    {
        public RoleRepository(NFineDbContext ctx) : base(ctx)
        {

        }
        public void DeleteForm(string keyValue)
        {
            using (var db = new RepositoryBase(dbcontext).BeginTrans())
            {
                db.Delete<RoleEntity>(t => t.Id == keyValue);
                db.Delete<RoleAuthorizeEntity>(t => t.ObjectId == keyValue);
                db.Commit();
            }
        }
        public void SubmitForm(RoleEntity roleEntity, List<RoleAuthorizeEntity> roleAuthorizeEntitys, string keyValue)
        {
            using (var db = new RepositoryBase(dbcontext).BeginTrans())
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    db.Update(roleEntity);
                }
                else
                {
                    roleEntity.Category = 1;
                    db.Insert(roleEntity);
                }
                db.Delete<RoleAuthorizeEntity>(t => t.ObjectId == roleEntity.Id);
                db.Insert(roleAuthorizeEntitys);
                db.Commit();
            }
        }
    }
}