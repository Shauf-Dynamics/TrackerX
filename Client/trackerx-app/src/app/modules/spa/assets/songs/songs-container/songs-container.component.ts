import { Component, OnInit } from '@angular/core';
import { AssetsModel } from '../../assets-container/models/assets-navigation';

@Component({
    selector: 'tx-songs-container',
    templateUrl: './songs-container.component.html',
    styleUrls: ['./songs-container.component.css']
})
export class SongsContainerComponent implements OnInit {        
    public assetsModel?: AssetsModel;

    public ngOnInit(): void {
        this.assetsModel = {
            header: 'Songs',
            description: 'Create and view your desirable songs. Customise and make it public so everyone can reuse it.',
            navigation: [
                {
                    title: 'My Songs',
                    description: 'Search for your person songs',
                    link: '/'
                },   
                {
                    title: 'Global',
                    description: 'Search for all added songs',
                    link: '/app/songs/global'
                },   
                {
                    title: 'Create',
                    description: 'Add and even share you music',
                    link: '/'
                },   
                {
                    title: 'Proposals',
                    description: 'Track the status of shared music',
                    link: '/'
                },   
            ]
        }
    }
}