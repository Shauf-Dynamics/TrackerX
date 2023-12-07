import { Component, OnInit } from '@angular/core';
import { AssetsModel } from '../../assets-container/models/assets-navigation';

@Component({
    selector: 'tx-music-container',
    templateUrl: './music-container.component.html',
    styleUrls: ['./music-container.component.css']
})
export class MusicContainerComponent implements OnInit {        
    public assetsModel?: AssetsModel;

    public ngOnInit(): void {
        this.assetsModel = {
            header: 'Music',
            description: 'Create and view your desirable songs. Customise and make it public so everyone can reuse it.',
            navigation: [
                {
                    title: 'My Music',
                    description: 'Search for your person music',
                    link: '/'
                },   
                {
                    title: 'Global Songs',
                    description: 'Search for all added songs',
                    link: '/app/music/global'
                },   
                {
                    title: 'Create',
                    description: 'Add and even share you music',
                    link: '/'
                },   
                {
                    title: 'Proposals',
                    description: 'Track the status of shared songs',
                    link: '/'
                },   
            ]
        }
    }
}