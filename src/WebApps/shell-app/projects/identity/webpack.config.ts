import { Configuration, container } from 'webpack';
import dep from 'package.json';

export const webpackConfig: Configuration = {
    output: {
        publicPath: 'http://localhost:8001/',
        uniqueName: 'identity',
    },
    experiments: {
        topLevelAwait: true,
    },
    optimization: {
        runtimeChunk: false,
    },
    plugins: [
        new container.ModuleFederationPlugin({
            name: 'identity',
            library: { type: 'var', name: 'identity' },
            filename: 'remoteIdentity.js',
            exposes: {
                LoginModule: 'projects/identity/src/app/app.module.ts',
                LoginComponent: 'projects/identity/src/app/login/login.component.ts'
            },
            shared: {
                '@angular/core': {
                    eager: true,
                    singleton: true,
                    strictVersion: true,
                    requiredVersion: dep.dependencies['@angular/core']
                },
                '@angular/common': {
                    eager: true,
                    singleton: true,
                    strictVersion: true,
                    requiredVersion: dep.dependencies["@angular/common"]
                },
                '@angular/router': {
                    eager: true,
                    singleton: true,
                    strictVersion: true,
                    requiredVersion: dep.dependencies["@angular/router"],
                },
            }
        })
    ]
};

export default webpackConfig;