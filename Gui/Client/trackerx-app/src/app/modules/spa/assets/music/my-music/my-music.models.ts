export class MyMusicViewModel {
    public musicId!: number;
    public description!: string;
    public type!: string;
    public visibility!: string;
    public addedDate!: Date;    

    constructor(musicId: number, description: string, type: string, visibility: string, addedDate: Date) {        
        this.musicId = musicId;
        this.description = description;
        this.type = type;
        this.visibility = visibility;
        this.addedDate = addedDate;
    }
}