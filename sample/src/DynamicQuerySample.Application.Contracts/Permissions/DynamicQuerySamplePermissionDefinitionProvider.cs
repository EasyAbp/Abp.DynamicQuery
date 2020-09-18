﻿using DynamicQuerySample.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace DynamicQuerySample.Permissions
{
    public class DynamicQuerySamplePermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(DynamicQuerySamplePermissions.GroupName);

            //Define your own permissions here. Example:
            //myGroup.AddPermission(DynamicQuerySamplePermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<DynamicQuerySampleResource>(name);
        }
    }
}
