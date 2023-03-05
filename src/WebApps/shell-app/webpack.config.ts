import { Configuration, container } from 'webpack';
import dep from 'package.json';

export const webpackConfig: Configuration = {
    output: {
        publicPath: 'http://localhost:7000/',
        uniqueName: 'shell',
    },
    experiments: {
        topLevelAwait: true,
    },
    optimization: {
        runtimeChunk: false,
    },
    plugins: [
        new container.ModuleFederationPlugin({
            name: 'shell',
            library: { type: 'var', name: 'shell' },
            filename: 'remoteShell.js',
            shared: {
                '@angular/core': {
                    eager: true,
                    singleton: true,
                    strictVersion: true,
                    requiredVersion: dep.dependencies["@angular/core"],
                },
                '@angular/common': {
                    eager: true,
                    singleton: true,
                    strictVersion: true,
                    requiredVersion: dep.dependencies["@angular/common"],
                },
                '@angular/router': {
                    eager: true,
                    singleton: true,
                    strictVersion: true,
                    requiredVersion: dep.dependencies["@angular/router"],
                },
                "@angular/common/http": { 
                    eager: true,
                    singleton: true,
                    strictVersion: true,
                    requiredVersion: '14.2.12'
                }
            }
        })
    ]
};

export default webpackConfig;